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
            try
            {
                BetterCLuster.Setup.SetupProcess.FirstRunCheck();
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