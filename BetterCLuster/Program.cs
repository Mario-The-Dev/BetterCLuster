using System;
using ScriptEx;
using userSystem;
using CommandHandlerNamespace;
using BetterCLuster.Program.use.only.ui;
using BetterCLuster.Program.use.only.Menus;
using BetterCLuster.Program.use.only.global;

namespace MainNamespace
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Set window size
            Console.SetWindowPosition(0, 0);
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            try
            {
                Menu.FullScreen();  
                Menu.StartUpOptions();
                Console.WriteLine(UI.Head(Global.date));
                CommandHandler commandHandler = new CommandHandler();
                while (true)
                {
                    UI.CommandInputBox();
                    Global.input = Console.ReadLine();
                    commandHandler.ExecuteCommand(Global.input);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}