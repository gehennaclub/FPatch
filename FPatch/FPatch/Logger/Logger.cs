﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPatch.Logger
{
    public class Logger
    {
        private Logs logs = new Logs();
        private Dictionary<Logs.Type, string> icons = new Dictionary<Logs.Type, string>()
        {
            { Logs.Type.information, "[ - ]" },
            { Logs.Type.wait, "[ . ]" },
            { Logs.Type.success, "[ + ]" },
            { Logs.Type.error, "[ x ]" },
            { Logs.Type.normal, "" },
            { Logs.Type.item, "[ > ]" },
            { Logs.Type.received, "R >>" },
            { Logs.Type.sent, "S >>" }
        };

        private Dictionary<Logs.Type, ConsoleColor> colors = new Dictionary<Logs.Type, ConsoleColor>()
        {
            { Logs.Type.information, ConsoleColor.White },
            { Logs.Type.wait, ConsoleColor.White },
            { Logs.Type.success, ConsoleColor.Green },
            { Logs.Type.error, ConsoleColor.Red },
            { Logs.Type.normal, ConsoleColor.White },
            { Logs.Type.item, ConsoleColor.White },
            { Logs.Type.received, ConsoleColor.White },
            { Logs.Type.sent, ConsoleColor.White }
        };

        public void display(string message, Logs.Type type)
        {
            string icon = icons[type];
            ConsoleColor color = colors[type];
            ConsoleColor reset = ConsoleColor.White;

            Console.ForegroundColor = color;
            Console.WriteLine($"{icon} {message}");
            Console.ForegroundColor = reset;
        }
    }
}
