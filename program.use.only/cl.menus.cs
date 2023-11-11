using System;
using ScriptEx;
using userSystem;
using BetterCLuster.Program.use.only.ui;
using Spectre.Console;
using BetterCLuster.Program.use.only.global;

namespace BetterCLuster.Program.use.only.Menus
{
    public class Menu
    {
        private static string MenuSelection()
        {
            var optionPrompt = new SelectionPrompt<string>()
                .AddChoices(new[] {
                    "Login", "Register","Refresh", "Exit"
                });
            
            return AnsiConsole.Prompt(optionPrompt);
        }
        public static void StartUpOptions()
        {
            try
            {
                UI.HugeText($"BetterCLuster v{Global.version}", Color.White, "center");
                UI.Header("SELECT OPTIONS", "lime");
                string option = MenuSelection();
                if (option == "Login")
                {
                    UserSystem.LoginUser();
                }else if (option == "Register")
                {
                    UserSystem user = new UserSystem();
                    user.RegisterUser();
                }else if (option == "Refresh")
                {
                    Console.Clear();
                    Menu.StartUpOptions();
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