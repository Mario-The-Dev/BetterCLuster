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
                //      name
                //      path to the executable
                //      > the Global will create a file in E:\.BetterCLuster\.shortRun.shortcuts 
                //        which will be named the name given by the user and the content in the file will be the path to the .exe
                string nameOfTheShortCut_Path;

                UI.HugeText("Shr", Spectre.Console.Color.Orange1, "center");
                UI.Header("Shortcuts in the command line. Do 'shr -run' to execute a shortcut", "lime");
                string? ShortCutName = UI.Propmt("Name the shortcut", "cyan", "white", false);
                DRY.Debug("-----");

                List<string> TypesOfShortCut = new List<string>() {"Executable UI application", "Executable CLI application"};
                string TypeOfShortCut = UI.SelectionPrompt("Type Of ShortCut", TypesOfShortCut);

                string? PathToExecutable = UI.Propmt("Path of the Executable", "cyan", "white", false);
                
                if (File.Exists(PathToExecutable))
                {
                    nameOfTheShortCut_Path = @$"E:\.BetterCLuster\.shortRun.shortcuts\"+ShortCutName;
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
            string name;
            string[] shortcutfiles = Directory.GetFiles(@"E:\.BetterCLuster\.shortRun.shortcuts\");
            Console.Write("ShortCut Name:  ");
            name = Console.ReadLine();

            if(shortcutfiles.Contains(@"E:\.BetterCLuster\.shortRun.shortcuts\"+name) == false){
                DRY.PrintError("The ShortCut doesn't exist");
            }else if (shortcutfiles.Contains(@"E:\.BetterCLuster\.shortRun.shortcuts\"+name))
            {
                List<string> properties = new List<string>();
                string[] lines = File.ReadAllLines(@"E:\.BetterCLuster\.shortRun.shortcuts\"+name);
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