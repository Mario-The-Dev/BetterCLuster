using System;
using BetterCLuster.Program.use.only.global;
using ScriptEx;
using System.Diagnostics;
using System.Text.RegularExpressions;
namespace BetterCLuster.application.multiShell
{
    internal class multiShell
    {
        public static void multiShellManager()
        {
            if (Global.input.Contains("mS "))
            {
                if (Global.input.Contains("-cmd"))
                {
                    useCommandPropmt(ExtractText(Global.input));
                }else if (Global.input.Contains("-ps"))
                {
                    usePowerShell(ExtractText(Global.input));
                }
                else
                {
                    DRY.PrameterException();
                }
            }
            else
            {

            }
        }

        private static void useCommandPropmt(string command)
        {
            try
            {
                // Create a new process
                Process process = new Process();

                // Set the process start information
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = "cmd.exe",    // Specify the command interpreter
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

        private static void usePowerShell(string command)
        {
            try
            {
                // Create a new process
                Process process = new Process();

                // Set the process start information
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = "powershell.exe",    // Specify the command interpreter
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

        private static string ExtractText(string textWithinQuotesOrCommand)
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