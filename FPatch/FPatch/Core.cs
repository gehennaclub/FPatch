using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPatch
{
    public class Core
    {
        private byte[] bytes { get; set; }
        private Configuration.Model.Rootobject model { get; set; }
        private Configuration.Reader reader { get; set; }
        private Configuration.Writter writter { get; set; }
        private Logger.Logger logger { get; set; }

        public Core(string author, string version)
        {
            model = init_model(author, version);
            reader = new Configuration.Reader();
            writter = new Configuration.Writter();
            logger = new Logger.Logger();

            load_settings();
        }

        private Configuration.Model.Rootobject init_model(string author, string version)
        {
            Configuration.Model.Rootobject model = new Configuration.Model.Rootobject()
            {
                settings = new Configuration.Model.Settings()
                {
                    version = Settings.Core.version
                },
                patch = new Configuration.Model.Patch()
                {
                    author = author,
                    version = version,
                    content = new List<Types.Patch>()
                }
            };

            return (model);
        }

        public Types.Patch create(string file, UInt32 offset, UInt32[] payload)
        {
            logger.display($"Creating patch: {offset}", Logger.Logs.Type.wait);
            Types.Patch patch = new Types.Patch()
            {
                status = Types.Patch.States.not_patched,
                file = file,
                payload = new Address.Pointer(offset, payload),
            };

            return (patch);
        }

        public void create_and_add(string file, UInt32 offset, UInt32[] payload)
        {
            add(create(file, offset, payload));
        }

        public void add(Types.Patch patch)
        {
            logger.display($"Adding patch to model: {patch.payload.start}", Logger.Logs.Type.wait);
            model.patch.content.Add(patch);
        }

        public void load(string path)
        {
            logger.display($"Loading model", Logger.Logs.Type.wait);
            model = reader.load(path);
            logger.display($"Model loaded", Logger.Logs.Type.success);
        }

        public void restore()
        {
            logger.display($"Starting restore", Logger.Logs.Type.wait);
            foreach (Types.Patch patch in model.patch.content)
            {
                logger.display($"Recovering '{patch.file}'", Logger.Logs.Type.item);
                recover(patch.file);
            }
            logger.display($"Restore completed", Logger.Logs.Type.information);
        }

        public void recover(string file)
        {
            string backup_output = $"{file}.bak";

            if (File.Exists(file) == true)
            {
                logger.display($"Deleting '{file}'", Logger.Logs.Type.item);
                File.Delete(file);
                logger.display($"'{file}' deleted", Logger.Logs.Type.information);
            }
            if (File.Exists(backup_output) == true)
            {
                logger.display($"Moving backup", Logger.Logs.Type.item);
                File.Move(backup_output, file);
                logger.display($"Backup moved", Logger.Logs.Type.information);
            }
        }

        public void save()
        {
            logger.display($"Saving model", Logger.Logs.Type.wait);
            writter.save(model);
            logger.display($"Model saved", Logger.Logs.Type.success);
        }

        public void apply()
        {
            workplace();
        }

        private void load_settings()
        {
            foreach (string line in Settings.Core.banner)
            {
                Console.WriteLine(line);
            }
            Console.WriteLine($"version: {Settings.Core.version}\n");
        }

        private void workplace()
        {
            logger.display($"Starting patch", Logger.Logs.Type.wait);
            foreach (Types.Patch patch in model.patch.content)
            {
                logger.display($"Applying '{patch.file}' patch", Logger.Logs.Type.item);
                if (check_file(patch.file) == true)
                {
                    backup_file(patch.file);
                    load_bytes(patch.file);
                    apply_patch(patch);
                    save_bytes(patch.file);
                }
                if (patch.status == Types.Patch.States.patched)
                {
                    logger.display($"Patch applied", Logger.Logs.Type.success);
                } else
                {
                    logger.display($"Patch not applied", Logger.Logs.Type.error);
                }
            }
            logger.display($"All patch completed", Logger.Logs.Type.information);
        }

        private void apply_patch(Types.Patch patch)
        {
            bytes = patch.payload.replace(bytes);
            patch.status = Types.Patch.States.patched;
        }

        private bool check_file(string file)
        {
            bool status = File.Exists(file);

            logger.display($"Checking file: {status}", Logger.Logs.Type.item);

            return (status);
        }

        private void backup_file(string file)
        {
            string backup_output = $"{file}.bak";

            logger.display($"Building backup", Logger.Logs.Type.item);

            if (File.Exists(backup_output) == true)
            {
                logger.display($"Deleting previous backup", Logger.Logs.Type.item);
                File.Delete(backup_output);
                logger.display($"Backup deleted", Logger.Logs.Type.success);
            }
            File.Copy(file, backup_output);

            logger.display($"Backup built", Logger.Logs.Type.information);
        }

        private void load_bytes(string file)
        {
            logger.display($"Loading bytes", Logger.Logs.Type.item);

            bytes = File.ReadAllBytes(file);

            logger.display($"{bytes.Count()} bytes loaded", Logger.Logs.Type.information);
        }

        private void save_bytes(string file)
        {
            logger.display($"Saving bytes", Logger.Logs.Type.item);

            File.WriteAllBytes(file, bytes);

            logger.display($"{bytes.Count()} bytes saved", Logger.Logs.Type.information);
        }
    }
}
