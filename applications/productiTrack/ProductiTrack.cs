using BetterCLuster.Program.use.only.global;
using BetterCLuster.Program.use.only.ui;
using ScriptEx;

namespace BetterCLuster.application.ProductiTracker
{
    public class ProductiTrackerCommand : ICommand
    {
        public void Execute()
        {
            ProductiTracker.Prompt();
        }
    }

    class ProductiTracker
    {
        /*
            > Task Logging
            > Goal Setting
            > Reminders
        */

        public static void Prompt()
        {
            //UI.HugeText("ProductiTracker v1.0", Spectre.Console.Color.Orange1, "center");
            List<string> options = new List<string>() {"Log a Task", "Read Log","Reset Log" , "Remind Me", "Reset Reminders", "Exit"};
            while (true)
            {
                string selectedOptions = UI.SelectionPrompt("[white bold]ProductiTracker v1.0[/]", options);

                if (selectedOptions == "Log a Task")
                {
                    TaskLogger(UI.Propmt("Task", "cyan", "white", false));
                    break;
                }else if (selectedOptions == "Read Log")
                {
                    ReadLog();
                    break;
                }else if (selectedOptions == "Reset Log")
                {
                    ResetLog();
                    break;
                }else if (selectedOptions == "Remind Me")
                {
                    SetReminder(UI.Propmt("Task", "cyan", "white", false));
                    break;
                }else if (selectedOptions == "Reset Reminders")
                {
                    ResetReminder();
                    break;
                }else if (selectedOptions == "Exit")
                {
                    break;
                }
                else
                {
                    DRY.PrintError("The option isn't supported or doesn't exist");
                }
            }
        }

        private static void TaskLogger(string Text)
        {
            using (StreamWriter sw = File.AppendText(@$"C:\Users\{Environment.UserName}\AppData\Roaming\BetterCLuster\Users\{Global.currentLoggedUser}\Outputs\tasks.txt"))
            {
                sw.WriteLine($"{DateTime.Now} | {Text}");
                DRY.Completed($"LOGGED SUCCESSFULLY '{DateTime.Now} | {Text}'");
            }
        }

        private static void ReadLog()
        {
            UI.Header("Start of Log File", "lime");
            string[] logged = File.ReadAllLines(@$"C:\Users\{Environment.UserName}\AppData\Roaming\BetterCLuster\Users\{Global.currentLoggedUser}\Outputs\tasks.txt");
            foreach (string log in logged)
            {
                Console.WriteLine(log);
            }
            UI.Header("End of Log File", "lime");
        }

        private static void ResetLog()
        {
            File.Delete(@$"C:\Users\{Environment.UserName}\AppData\Roaming\BetterCLuster\Users\{Global.currentLoggedUser}\Outputs\tasks.txt");
            DRY.Completed("Log Reseted");
        }

        private static void SetReminder(string Reminder)
        {
            Global.Reminder = Reminder;
            DRY.Completed("Reminder Set");
        }
        private static void ResetReminder()
        {
            Global.Reminder = "No Reminders";
            DRY.Completed("Reminder Reset");
        }
    }
}