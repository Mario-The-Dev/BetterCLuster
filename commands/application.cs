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
            info.Add($"Description : BetterCLuster is a Terminal based on the Cluster-Terminal. I know it's weird bascially BetterCLuster is sequel to Cluster-Terminal");
            info.Add($"Build Name : {Global.Build}");
            info.Add($"Made on : 29/04/2023");
            info.Add($"lang written on : C#(C sharp)");
            info.Add($"File Manager : Cluster v3.0");
            info.Add($"Credits : Mario-The-Dev\n");
            UI.Output(info);
        }
    }
}
