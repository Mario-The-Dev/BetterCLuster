using System;
using BetterCLuster.Program.use.only.global;
using ScriptEx;
using System.Diagnostics;
using System.Text.RegularExpressions;
namespace BetterCLuster.application.multiShell
{
    public class msCmd : ICommand
    {
        public void Execute()
        {
            //multiShell.useCommandPropmt();
        }
    }

    public class msPowerShell : ICommand
    {
        public void Execute()
        {
            //multiShell.usePowerShell();
        }
    }

    internal class multiShell
    {

        public static void useCommandPropmt(string command)
        {
            try
            {
                // Create a new process
                Process process = new Process();

                // Set the process start information
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = @"C:\Windows\System32\cmd.exe",    // Specify the command interpreter
                    RedirectStandardInput = true,   // Redirect input
                    RedirectStandardOutput = true,  // Redirect output
                    CreateNoWindow = true,          // Do not create a window
                    UseShellExecute = false         // Do not use the shell to execute the command
                };

                process.StartInfo = startInfo;

                // Start the process
                process.Start();

                // Send commands to the CMD process
                process.StandardInput.WriteLine(command);

                // Read the output of the CMD process
                string output = process.StandardOutput.ReadToEnd();

                // Wait for the process to exit
                process.WaitForExit();

                // Display the output
                Console.WriteLine(output);
                process.StandardInput.WriteLine("exit");
            }catch(Exception ex)
            {
                DRY.PrintError(ex.Message);
            }
        }

        public static void usePowerShell(string command)
        {
            try
            {
                // Create a new process
                Process process = new Process();

                // Set the process start information
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = @"C:\Windows\System32\WindowsPowerShell\v1.0\powershell.exe",    // Specify the command interpreter
                    RedirectStandardInput = true,   // Redirect input
                    RedirectStandardOutput = true,  // Redirect output
                    CreateNoWindow = true,          // Do not create a window
                    UseShellExecute = false         // Do not use the shell to execute the command
                };

                process.StartInfo = startInfo;

                // Start the process
                process.Start();

                // Send commands to the CMD process
                process.StandardInput.WriteLine(command);

                // Read the output of the CMD process
                string output = process.StandardOutput.ReadToEnd();

                // Wait for the process to exit
                process.WaitForExit();

                // Display the output
                Console.WriteLine(output);
                process.StandardInput.WriteLine("exit");
            }catch(Exception ex)
            {
                DRY.PrintError(ex.Message);
            }
        }

        public static string ExtractText(string textWithinQuotesOrCommand)
        {
            // Define the regular expression pattern to match text within double quotes
            string pattern = "\"(.*?)\"";

            // Match the pattern within the command string
            Match match = Regex.Match(textWithinQuotesOrCommand, pattern);

            if (match.Success)
            {
                // Extract the text within the double quotes
                string textWithinQuotes = match.Groups[1].Value;

                // Display the extracted text
                return textWithinQuotes;
            }
            else
            {
                DRY.PrintError("No text within double quotes found.");
                return null;
            }

        }
    }
}