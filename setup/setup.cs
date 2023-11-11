using System;
using System.Diagnostics;
using BetterCLuster.Program.use.only.ui;
using System.IO;
using Spectre.Console;
using ScriptEx;
using BetterCLuster.Program.use.only.global;
using BetterCLuster.Program.use.only.Menus;
namespace BetterCLuster.Setup
{
    public class SetupProcess
    {
        /*
            Check if the application is run for the first time,
            if so: Ask for the path/root for the files and directories to be created. User will be directed
            on what the user should do in each step. The process will be simple. Afterwards a simple explaination
            on how to use the application will be presented to the user
            
            else if the application was not run for the first time contine to startup options
        */
        public static void FirstRunCheck()
        {
            string currentProcessName = Process.GetCurrentProcess().ProcessName;
            bool isFirstRun = IsFirstRun(currentProcessName);

            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string AppDataPath = Path.Combine(appDataPath, "BetterCLuster");
            
            if (isFirstRun)
            {
                if(Directory.Exists(AppDataPath))
                {
                    
                }else{
                    SetupDirectoriesAndFiles.Welcome();
                }
            }
            else
            {
                
            }
        }

        static bool IsFirstRun(string processName)
        {
            Process[] runningProcesses = Process.GetProcessesByName(processName);
            return runningProcesses.Length == 1;
        }

    }
    public class SetupDirectoriesAndFiles
    {
        public static void Welcome()
        {
            try
            {
                UI.HugeText($"BetterCLuster v{Global.version}", Color.Lime, "center");
                AnsiConsole.Write(Align.Center(new Markup("Welcome to BetterCLuster! Elevate your command-line experience with Spectre.Console and Spectre.Console.ImageSharp. Get ready to supercharge productivity. Installation is easy, and you're just moments away from a powerful CLI experience. Let's dive in! \n [bold white]Using a nerd font is highly recommended.[/]")));
                Console.Write($"\n");
                UI.Header("Credits", "lime");
                AnsiConsole.Write(Align.Center(new Markup("Programming: [link=https://mario-the-dev.github.io/]Mario-The-Dev[/]")));
                AnsiConsole.Write(Align.Center(new Markup("[lime bold] Libraries [/]")));
                AnsiConsole.Write(Align.Center(new Markup("Spectre.Console, Spectre.Console.ImageSharp, IronPython")));
                Console.Write($"\n");
                UI.Header("Setup", "lime");
                AnsiConsole.Write(Align.Center(new Markup("All Program Files will be Created at [red]%AppData% Directory[/]. Outputs from BetterCLuster can be accessed by logining to that user's account & executing the [white bold]'outputs'[/] command.")));
                Console.Write($"\n");
                Console.Write($"\n");
                AnsiConsole.Write(Align.Center(new Markup("[lime] [[ENTER]] Key to Continue the Setup Process [/]")));
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.Enter)
                {
                    AnsiConsole.Write(Align.Center(new Markup("Creating Directories...")));
                    CreateFoldersAndFiles();
                    AnsiConsole.Write(Align.Center(new Markup("The Setup Process is Complete!")));
                    Console.ReadKey();
                    Console.Clear();
                    Menu.StartUpOptions();
                }else
                {
                    Environment.Exit(0);
                }
            }
            catch (Exception ex)
            {
                DRY.PrintError($"Setup Error: {ex.Message}");
            }
        }

        public static void CreateFoldersAndFiles()
        {
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string AppDataPath = Path.Combine(appDataPath, "BetterCLuster");
            Directory.SetCurrentDirectory(appDataPath);
            Directory.CreateDirectory(AppDataPath);
            Directory.SetCurrentDirectory(AppDataPath);
            Directory.CreateDirectory("Users");
            Directory.SetCurrentDirectory(@"Users");
        }
    }
}