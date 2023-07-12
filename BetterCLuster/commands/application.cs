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

    public class ChangeColorAll : ICommand
    {
        public void Execute()
        {
            Console.WriteLine("Enter BG colour");
            string? bgcolour = Console.ReadLine();

            if (bgcolour == "white")
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
            }
            else if (bgcolour == "black")
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (bgcolour == "blue")
            {
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (bgcolour == "darkblue")
            {
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (bgcolour == "darkcyan")
            {
                Console.BackgroundColor = ConsoleColor.DarkCyan;
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (bgcolour == "green")
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (bgcolour == "darkgreen")
            {
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }

    public class ChangeColorFont : ICommand
    {
        public void Execute()
        {
            Console.WriteLine("Enter font colour");
            string? bgcolour = Console.ReadLine();

            if (bgcolour == "white")
            {
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (bgcolour == "black")
            {
                Console.ForegroundColor = ConsoleColor.Black;
            }
            else if (bgcolour == "blue")
            {
                Console.ForegroundColor = ConsoleColor.Blue;
            }
            else if (bgcolour == "darkblue")
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
            }
            else if (bgcolour == "darkcyan")
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
            }
            else if (bgcolour == "green")
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else if (bgcolour == "darkgreen")
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
            }
        }
    }


////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
}
