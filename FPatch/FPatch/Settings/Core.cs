using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPatch.Settings
{
    public class Core
    {
        public enum Version
        {
            major = 0,
            minor = 1,
            extra = 2
        };

        public static readonly Dictionary<Version, string[]> updates = new Dictionary<Version, string[]>()
        {
            {
                Version.major,
                new string[]
                {
                    "first release"
                }
            },
            {
                Version.minor,
                new string[]
                {
                    "add insert method for patch, add functions methods mapping",
                    "add restore function to restore all patched files as default",
                    "add tools > payload > build(string)"
                }
            },
            {
                Version.extra,
                new string[]
                {
                    "update log messages & colors",
                    "update output file name"
                }
            },
        };
        public static readonly string version = $"{updates[Version.major].Count()}.{updates[Version.minor].Count()}.{updates[Version.extra].Count()}";
        public static readonly string[] banner = new string[] {
            " _____ _____     _       _   ",
            "|   __|  _  |___| |_ ___| |_ ",
            "|   __|   __| .'|  _|  _|   |",
            "|__|  |__|  |__,|_| |___|_|_|",
            "               Author: neo"
        };       
    }
}
