using System;
using BetterCLuster.Program.use.only.ui;
using BetterCLuster.Program.use.only.global;
using Spectre.Console;

namespace BetterCLuster.Commands.application
{
    public class Exit : ICommand
    {
        public void Execute()
        {
            Environment.Exit(0);
        }
    }

    public class DateAndTime : ICommand
    {
        public void Execute()
        {
            Console.WriteLine(DateTime.Now);
        }
    }

    public class Clear : ICommand
    {
        public void Execute()
        {
            Console.Clear();
            Console.WriteLine(UI.Head(Global.date));
        }
    }

    public class Info : ICommand
    {
        public void Execute()
        {
            UI.HugeText($"BetterCLuster v{Global.version}", Color.Lime, "center");
            AnsiConsole.WriteLine();
            List<string> info = new List<string>();
            info.Add($"Version : BetterCluster v{Global.version}");
            info.Add($"Created on : 29/04/2023");
            info.Add($"lang written on : C#(C sharp)");
            info.Add($"File Manager : Cluster v3.1");
            info.Add($"Credits : Mario-The-Dev\n");
            UI.Output(info);
        }
    }
}
