using System;
using ScriptEx;
using BetterCLuster.Program.use.only.global;
using System.Diagnostics;
using CommandHandlerNamespace;
using BetterCLuster.Program.use.only.ui;

namespace BetterCLuster.application.shortRun
{
    public class shortRun_Create : ICommand
    {
        public void Execute()
        {
            shortRun.createShortCut();
        }
    }

    public class shortRun_Run : ICommand
    {
        public void Execute()
        {
            shortRun.runShortCut();
        }
    }

    internal class shortRun
    {
        public static void createShortCut(){
            try
            {
                string nameOfTheShortCut_Path;

                UI.HugeText("Shr", Spectre.Console.Color.Orange1, "center");
                UI.Header("Shortcuts in the command line. Do 'shr -run' to execute a shortcut", "lime");
                string? ShortCutName = UI.Propmt("Name the shortcut", "cyan", "white", false);

                List<string> TypesOfShortCut = new List<string>() {"Executable UI application", "Executable CLI application"};
                string TypeOfShortCut = UI.SelectionPrompt("Type Of ShortCut", TypesOfShortCut);

                string? PathToExecutable = UI.Propmt("Path of the Executable", "cyan", "white", false);
                
                if (File.Exists(PathToExecutable))
                {
                    nameOfTheShortCut_Path = @$"C:\Users\mario\AppData\Roaming\BetterCLuster\Users\{Global.currentLoggedUser}\ShortCuts\"+ShortCutName;
                    using (StreamWriter sw = new StreamWriter(nameOfTheShortCut_Path))
                    {
                        sw.WriteLine($"{PathToExecutable}");
                        sw.WriteLine($"{TypeOfShortCut}");
                    }
                    DRY.Completed("ShortCut was successfully created!");
                }else{
                    DRY.PrintError("The Provided Path doesn't exist or is incorrect.");
                }
            }catch(Exception ex){
                DRY.PrintError(ex.Message);
            }
            
        }

        public static void runShortCut()
        {                                                                   
            List<string> shortcutfiles = new List<string>(Directory.GetFiles(@$"C:\Users\mario\AppData\Roaming\BetterCLuster\Users\{Global.currentLoggedUser}\ShortCuts"));
            string name = UI.SelectionPrompt("Select a Shortcut", shortcutfiles);

            if (shortcutfiles.Contains(name))
            {
                List<string> properties = new List<string>();
                string[] lines = File.ReadAllLines(name);
                foreach (string line in lines)
                {
                    properties.Add(line);
                }

                if (properties[1] == "Executable UI application")
                {
                    runUI(properties[0]);
                }else if (properties[1] == "Executable CLI application")
                {
                    runCL(properties[0]);
                }else{
                    DRY.PrintError("Unknown Error");
                }

            }else
            {
                
            }
        }


        private static void runCL(string path){
            string? applicationOrDirectorytheAppliactionIsFound = path;
            Console.Title = $"BetterCLuster >>> {applicationOrDirectorytheAppliactionIsFound}";
            Console.WriteLine($"Starting {applicationOrDirectorytheAppliactionIsFound}...");
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = applicationOrDirectorytheAppliactionIsFound;
            startInfo.UseShellExecute = false;
            startInfo.CreateNoWindow = false;

            Process process = new Process();
            process.StartInfo = startInfo;
            process.Start();
            Console.WriteLine($"Task Completed {applicationOrDirectorytheAppliactionIsFound}\n\t Waiting till {applicationOrDirectorytheAppliactionIsFound} is closed");
            process.WaitForExit();
            CommandHandler CH = new CommandHandler();
            CH.ExecuteCommand("cls");
        }

        private static void runUI(string path){
            string? applicationOrDirectorytheAppliactionIsFound = path;

            Console.Title = $"BetterCLuster >>> {applicationOrDirectorytheAppliactionIsFound}";
            Console.WriteLine($"Starting {applicationOrDirectorytheAppliactionIsFound}...");
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = applicationOrDirectorytheAppliactionIsFound;
            startInfo.CreateNoWindow = true;

            Process process = new Process();
            process.StartInfo = startInfo;
            process.Start();
            Console.WriteLine($"Task Completed {applicationOrDirectorytheAppliactionIsFound}...\n\t Cluster will function as normal");
        }
    }
}