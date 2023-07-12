using System;
using ScriptEx;
using BetterCLuster.Program.use.only.global;
using System.Diagnostics;
using CommandHandlerNamespace;

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
                string nameOfTheShortCut;
                string pathTo;
                string nameOfTheShortCut_Path;
                int type;
                string typeString=null;

                Console.Write("Name the shortcut: ");
                nameOfTheShortCut = Console.ReadLine();
                if (nameOfTheShortCut == null)
                {
                    DRY.PrintError("ShortCut name is null");
                    Console.ReadKey();
                    Reset();
                }else{

                }

                Console.WriteLine("Type:");
                Console.WriteLine("[1] Executable UI application");
                Console.WriteLine("[2] Executable CLI application");
                type = Convert.ToInt32(Console.ReadLine());

                if (type == 1)
                {
                    typeString = "Executable UI application";
                }else if (type == 2)
                {
                    typeString = "Executable CLI application";
                }else if(type == null || type == 0 || type >= 3)
                {
                    DRY.PrintError("'type' cannot be null or greater than '3! ");
                    Console.ReadKey();
                    Reset();
                }
                else{
                    DRY.PrintError("Unknown Error");
                    Console.ReadKey();
                    Reset();
                }

                Console.Write("File Path: ");
                pathTo = Console.ReadLine();

                if (File.Exists(pathTo))
                {
                    DRY.Completed("File Exists");
                }else
                {
                    DRY.PrintError("File does not exist");              
                    Console.ReadKey();
                    Reset();
                }

                nameOfTheShortCut_Path = @$"E:\.BetterCLuster\.shortRun.shortcuts\"+nameOfTheShortCut;
                using (StreamWriter sw = new StreamWriter(nameOfTheShortCut_Path))
                {
                    sw.WriteLine($"{pathTo}");
                    sw.WriteLine($"{typeString}");
                }
                DRY.Completed("ShortCut was successfully created!");
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
        private static void Reset(){
            createShortCut();
        }
    }
}