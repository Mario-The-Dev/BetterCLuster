using System;
using System.Diagnostics;
using System.Speech.Synthesis;

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

    public class ProcessList : ICommand
    {
        public void Execute()
        {
            Process[] processCollection = Process.GetProcesses();
            foreach (Process process in processCollection)
            {
                Console.WriteLine($"Process Name : {process.ProcessName,-40} | IsResponding : {process.Responding,20} |     Memory alocated for the process(KB & MB) : {process.PrivateMemorySize64 / 1024 + " KB",30}{process.PrivateMemorySize64 / 1024 / 1024 + " MB",10}");
            }
            Console.WriteLine($"\n'{processCollection.Length}' processors are currently running on your system. Use 'sysinfo -all' to get hardware info\n");
        }
    }
}
