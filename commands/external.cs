using System;
using System.Diagnostics;
using System.Speech.Synthesis;
using Spectre.Console;

namespace BetterCLuster.Commands.external
{
    public class CMD : ICommand
    {
        public void Execute()
        {
            Console.Title = "BetterCLuster by Mario-The-Dev >>> cmd.exe";
            Console.WriteLine("Starting Command Prompt...");
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = @"cmd.exe";
            startInfo.UseShellExecute = false;
            startInfo.CreateNoWindow = false;

            Process process = new Process();
            process.StartInfo = startInfo;
            process.Start();
            Console.WriteLine("Task Completed Command Prompt...");
            Console.Clear();
            process.WaitForExit();
        }
    }

    public class Launch_CL : ICommand
    {
        public void Execute()
        {
            Console.Write("Name of the (.exe) or the directory the (.exe) is stored in : ");
            string? applicationOrDirectorytheAppliactionIsFound = Console.ReadLine();

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
        }
    }

    public class Launch_UI : ICommand
    {
        public void Execute()
        {
            Console.Write("Name of the (.exe) or the directory the (.exe) is stored in : ");
            string? applicationOrDirectorytheAppliactionIsFound = Console.ReadLine();

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

    public class TextToSpeech_doc : ICommand
    {
        public void Execute()
        {
            Console.Write("Enter File : ");
            string? FileName = Console.ReadLine();

            SpeechSynthesizer speech = new SpeechSynthesizer();

            string[] lines = File.ReadAllLines(FileName);

            foreach (string line in lines)
            {
                Console.WriteLine(line);
                speech.Speak(line);
                Thread.Sleep(2);
            }
        }
    }

    public class TextToSpeech_text : ICommand
    {
        public void Execute()
        {
            Console.Write("Enter text : ");
            string? input = Console.ReadLine();
            SpeechSynthesizer speech = new SpeechSynthesizer();
            speech.Speak(input);
        }
    }

    public class CalendarNow : ICommand
    {
        public void Execute()
        {
            DateTime date = DateTime.Now;
            var calendar = new Spectre.Console.Calendar(date.Year, date.Month);
            Spectre.Console.AnsiConsole.Write(calendar);
        }
    }

    public class ProcessList : ICommand
    {
        public void Execute()
        {
            var table = new Table();

            string IsRespond = null;
            Process[] processCollection = Process.GetProcesses();
            var sortedProcesses = processCollection.OrderBy(p => p.ProcessName);
            table.AddColumn("Process Name");
            table.AddColumn("Status");
            table.AddColumn("Memory used(KB)");
            table.AddColumn("Memory used(MB)");
            foreach (Process process in sortedProcesses)
            {
                if(process.Responding == true)
                {
                    IsRespond = "Responding";
                }else{
                    IsRespond = "Not Responding";
                }

                table.AddRow(process.ProcessName, IsRespond, process.PrivateMemorySize64 / 1024 + " KB", process.PrivateMemorySize64 / 1024 / 1024 + " MB");
            }
            AnsiConsole.Write(table);
            Console.WriteLine($"\n'{processCollection.Length}' processors are currently running on your system. Use 'sysinfo -all' to get hardware info\n");
        }
    }
}
