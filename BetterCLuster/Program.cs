using CommandHandlerNamespace;
using BetterCLuster.Program.use.only.ui;
using BetterCLuster.Program.use.only.Menus;
using BetterCLuster.Program.use.only.global;
using ScriptEx;

namespace MainNamespace
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Set window size
            DRY.Debug("WindowsPos");
            Console.SetWindowPosition(0, 0);
            DRY.Debug("WindowSize");
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