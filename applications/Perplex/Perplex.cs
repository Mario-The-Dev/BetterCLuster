using System.ComponentModel;
using BetterCLuster.Program.use.only.global;
using BetterCLuster.Program.use.only.ui;
using ScriptEx;

namespace BetterCLuster.application.Perplex
{
    public class PerplexCommand: ICommand
    {
        public void Execute()
        {
            Perplex.Prompt();
        }
    }

    class Perplex
    {
        public static void Prompt()
        {
            List<string> options = new List<string>() {"Perplex Groups", "Remind Me", "Reset Reminders", "Exit"};
            while (true)
            {
                string selectedOptions = UI.SelectionPrompt("[white bold]Perplex v1.0[/]", options);

                if (selectedOptions == "Perplex Groups")
                {
                    PerplexGroups();
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

        private static void PerplexGroups()
        {
            string groupsdirectory = @$"{Global.AppDataPath}\Users\{Global.currentLoggedUser}\PerplexGroups\";
            string[] groupsdirectories = Directory.GetDirectories(groupsdirectory);
            while (true)
            {
                List<string> Groups = new List<string>();
                foreach (string group in groupsdirectories)
                {
                    Groups.Add(group.Replace(@$"C:\Users\{Environment.UserName}\AppData\Roaming\BetterCLuster\Users\{Global.currentLoggedUser}\PerplexGroups\", ""));
                }
                Groups.Add("[lime]Create Group[/]");
                Groups.Add("[lime]Back[/]");
                string selection = UI.SelectionPrompt("Your Groups", Groups);   

                if (selection == "[lime]Create Group[/]")
                {
                    CreateGroup(groupsdirectory);
                }else if (selection == "[lime]Back[/]")
                {
                    break;
                }else
                {
                    OpenGroup($"{groupsdirectory}{selection}");
                }   
            }
        }

        /* Group Related Functions */
        private static void CreateGroup(string groupsdirectory)
        {
            string groupName = UI.Propmt("Group Name", "cyan", "white", false);
            Directory.CreateDirectory(@$"{groupsdirectory}\{groupName}");
            DRY.Completed("Group Created");
        }

        private static void OpenGroup(string selected)
        {
            Directory.SetCurrentDirectory(selected);
            string[] tasks = Directory.GetFiles(Directory.GetCurrentDirectory());
            List<string> tasklist = new List<string>();
            foreach (string file in tasks)
            {
                string[] content = File.ReadAllLines(file);
                if (content.Contains("Completed"))
                {
                    tasklist.Add(file.Replace(selected + @"\", "[[ Completed ]] "));
                }else{
                    tasklist.Add(file.Replace(selected + @"\", ""));
                }
            }

            tasklist.Add("[lime]Create New Task[/]");
            tasklist.Add("[lime]Back[/]");
            string selection = UI.SelectionPrompt(Directory.GetCurrentDirectory().Replace(@$"C:\Users\{Environment.UserName}\AppData\Roaming\BetterCLuster\Users\{Global.currentLoggedUser}\PerplexGroups\", "Group: "), tasklist);  
            
            if (selection == "[lime]Create New Task[/]")
            {
                CreateTask(selected.Replace(@$"C:\Users\{Environment.UserName}\AppData\Roaming\BetterCLuster\Users\{Global.currentLoggedUser}\PerplexGroups\", ""));
            }else if(selection == "[lime]Back[/]"){

            }else
            {
                TaskOptions(selection);
            }        
        }

        /* Group Related Functions */

        /* Task Related Functions */
        private static void CreateTask(string groupName)
        {
            string name = UI.Propmt("Name", "cyan", "white", false);
            string type = UI.Propmt("Type(Feature Request, Bug Fix, etc)", "cyan", "white", false);
            string Todo = UI.Propmt("Description", "cyan", "white", false);

            using (StreamWriter sw = new StreamWriter($"{groupName} - {name}"))
            {
                sw.WriteLine($"Title: {name} | {type}");
                sw.WriteLine($"Author: {Global.currentLoggedUser}");
                sw.WriteLine($"{Todo}");
            }
            DRY.Completed("Task Added");
        }

        private static void TaskOptions(string taskFile)
        {
            string[] contents = File.ReadAllLines(taskFile);
            UI.Header("START", "lime");
            foreach (string line in contents)
            {
                Console.WriteLine(line);
            }
            UI.Header("END", "lime");

            List<string> options = new List<string>(){"Completed", "Delete", "Back"};
            string option = UI.SelectionPrompt("", options);
            if (option == "Completed")
            {
                using (StreamWriter sw = new StreamWriter(taskFile))
                {
                    sw.WriteLine("Completed");
                }
                DRY.Completed("Marked As Completed");
            }else if(option == "Delete")
            {
                File.Delete(taskFile);
                DRY.Completed("Task Deleted");
            }else{
                
            }
        }
        /* Task Related Functions */

        // Reminder

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