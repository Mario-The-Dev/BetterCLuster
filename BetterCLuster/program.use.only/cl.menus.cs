using System;
using ScriptEx;
using userSystem;
using BetterCLuster.Program.use.only.ui;
using Spectre.Console;

namespace BetterCLuster.Program.use.only.Menus
{
    public class Menu
    {
        public static void FullScreen()
        {
            Console.WriteLine("To run BetterCLuster you must be in FullScreen for the best experince [ ENTER ] key to continue");
            ConsoleKeyInfo key = Console.ReadKey();
            if (key.Key == ConsoleKey.Enter)
            {
                Console.WriteLine("Redirecting...");
            }else
            {
                Environment.Exit(0);
            }
            
        }
        private static string MenuSelection()
        {
            var optionPrompt = new SelectionPrompt<string>()
                .AddChoices(new[] {
                    "Login", "Register", "Exit"
                });

            return AnsiConsole.Prompt(optionPrompt);
        }
        public static void StartUpOptions()
        {
            try
            {
                UI.HugeText("BetterCLuster", Color.White, "center");
                UI.Header("SELECT OPTIONS", "lime");
                string option = MenuSelection();
                if (option == "Login")
                {
                    UserSystem.LoginUser();
                }else if (option == "Register")
                {
                    UserSystem user = new UserSystem();
                    user.RegisterUser();
                }else if (option == "Exit")
                {
                    Environment.Exit(0);
                }else
                {
                    DRY.PrintError("THE OPTION IS INVALID");
                    Thread.Sleep(3000);
                    Environment.Exit(0);
                }
            }
            catch (Exception ex)
            {
                DRY.PrintError(ex.Message);
                Thread.Sleep(3000);
                Environment.Exit(0);
            }
            
        }
    }
}