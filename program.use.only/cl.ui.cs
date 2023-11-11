using System;
using MainNamespace;
using System.Management;
using System.Security.Principal;
using ScriptEx;
using userSystem;
using BetterCLuster.Program.use.only.global;
using Spectre.Console;

namespace BetterCLuster.Program.use.only.ui
{
    class UI
    {
        public static void HugeText(string text, Color color, string align)
        {
            if (align == "center")
            {
                AnsiConsole.Write(
                new FigletText(text)
                    .Centered()
                    .Color(color));
            }else if (align == "left")
            {
                AnsiConsole.Write(
                new FigletText(text)
                    .LeftJustified()
                    .Color(color));
            }else if (align == "right")
            {
                AnsiConsole.Write(
                new FigletText(text)
                    .RightJustified()
                    .Color(color));
            }else
            {
                AnsiConsole.Write(
                new FigletText(text)
                    .Centered()
                    .Color(color));
            }
        }
        
        public static void Header(string header, string color)
        {
            AnsiConsole.WriteLine();
            var rule = new Rule($"[bold {color}]{header}[/]");
            AnsiConsole.Write(rule);
            AnsiConsole.WriteLine();
        }
        public static string Propmt(string prompt, string prompt_color, string input_color, bool mask)
        {
            if(mask == true)
            {
                return AnsiConsole.Prompt(
                new TextPrompt<string>($"[{prompt_color}]{prompt}[/]:")
                    .PromptStyle(input_color)
                    .Secret('*'));
            }else
            {
                return AnsiConsole.Prompt(
                new TextPrompt<string>($"[{prompt_color}]{prompt}[/]:")
                    .PromptStyle(input_color));
            }
            
        }

        

        public static void Output(List<string?> text_input)
        {
            try{
                Console.ForegroundColor = ConsoleColor.White;
                foreach (string text in text_input)
                {
                    Console.WriteLine(text);
                }
                Console.ForegroundColor = ConsoleColor.Gray;
            }catch(Exception ex)
            {
                DRY.PrintError(ex.Message);
            }
            
        }

        public static string SelectionPrompt(string title, List<string> choices)
        {
            var optionPrompt = new SelectionPrompt<string>()
                .Title(title)
                .AddChoices(choices);
            return AnsiConsole.Prompt(optionPrompt);
        }

        /* Command Box Methods */

        public static string Head(string special){
            Console.Title = $"BetterCLuster {Global.version}";
            Console.ForegroundColor = ConsoleColor.Gray;
            if (special == "29-04")
            {
                return $"\t \t \t Happy Birthday BetterCLuster  v{Global.version}\n";
            }else if (special == "25-12")
            {
                return $"\t \t \t Wishing you a Merry Christmas from BetterCLuster v{Global.version}\n";
            }else
            {
                return $"\t \t \t BetterCLuster v{Global.version}\n";
            }
        }

        private static bool _IsAdmin()
        {
            var identity = WindowsIdentity.GetCurrent();
            var principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }


        public static void CommandInputBox() {
            try
            {
                ManagementObjectSearcher mos = new ManagementObjectSearcher("select * from Win32_Battery");
                List<string> BatteryInfo = new List<string>();
                foreach (ManagementObject obj in mos.Get())
                {
                    BatteryInfo.Add(Convert.ToString(obj["EstimatedChargeRemaining"]));
                }

                string isAdminpropmt;
                string isAdminHeader;
                if (_IsAdmin() == true)
                {
                    isAdminpropmt = "$";
                    isAdminHeader = "In Administrator mode";
                }
                else
                {
                    isAdminpropmt = "#";
                    isAdminHeader = "In default mode";
                }
                Console.ForegroundColor = ConsoleColor.Gray;
                AnsiConsole.Write(new Markup($"[[ Build Name : {Global.Build} v{Global.version} │ {isAdminHeader} │ [red]{Global.Reminder}[/] │ {BatteryInfo[0]}% ]]"));Console.Write($"\n");
                Console.WriteLine($"├───[cd : {Directory.GetCurrentDirectory()} │ {Global.currentLoggedUser}]");
                Console.WriteLine($"│");
                Console.Write($"└───{isAdminpropmt} ");
                Console.ForegroundColor = ConsoleColor.White;
            }
            catch(Exception ex)
            {
                DRY.PrintError($"CLI Exception: {ex.Message}");
            }
        }
    }
}