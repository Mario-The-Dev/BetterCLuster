using BetterCLuster.Program.use.only.global;
using BetterCLuster.Program.use.only.ui;
using ScriptEx;
using System.Net;

namespace BetterCLuster.application.visel
{   

    public class Visel : ICommand
    {
        public void Execute()
        {
            ViselClass.ViselMenu();
        }
    }

    internal class ViselClass
    {
        public static void ViselMenu()
        {
            Console.Clear();
            string comm;
            Console.WriteLine($"Visel[1.0[alpha]] a simple command Line text editor\nFrom the developers of Cluster-Terminal");

            while (true)
            {
                Console.Write("Using BetterCluster >>> ");
                comm =  Console.ReadLine();
                if (comm == "edit" || comm == "insert" || comm == "i" || comm == "e")
                {
                    EditorClass editor = new EditorClass();
                    editor.Editor();
                }else if (comm == "exit")
                {
                   break;
                }else{
                    
                }
            }
        }
    }

    class EditorClass
    {
        public void Editor()
        {
            try
            {
                string filename;
                Console.Write(@"Enter File Name(E:\TestFile) : ");
                filename = Console.ReadLine();
                string fileName = filename + ".txt";

                Console.Clear();
                UI.Header("Visel Editor", "lime");
                bool IsEditing = true;
                int i = 1;
                List<string?> lines = new List<string>();

                while (IsEditing)
                {
                    Console.Write($"{$"ln {i}",7}│ ");
                    string text = Console.ReadLine();

                    if (text.Contains("::ex"))
                    {
                        DRY.Progress($"Stopping Editing Process");
                        IsEditing = false;
                        DRY.PrintError("File wasn't saved!");
                    }
                    else if (text.Contains("::edit"))
                    {
                        Console.Write("Which line do you want to re write : ");
                        int num = NumChange();
                        Console.WriteLine($"previous text '{lines[num]}'");
                        lines[num] = Console.ReadLine();
                        Refresh(lines);
                    }
                    else if (text.Contains("::sq"))
                    {
                        DRY.Progress("[->] Saving file...");
                        DRY.Progress($"Stopping Editing Process");
                        IsEditing = false;
                        using (StreamWriter sw = new StreamWriter(fileName))
                        {
                            foreach (string line in lines)
                            {
                                DRY.Progress($"Exporting line '{line}'");
                                sw.WriteLine(line);
                            }
                        }
                        UI.Header("Saved and Editing Completed", "lime");
                    }
                    else
                    {
                        lines.Add(text);
                    }
                    i++;
                }
            }
            catch (Exception ex)
            {
                DRY.PrintError(ex.Message);
            }

        }

        private static int NumChange()
        {
            int outputNum;
            int inputNum = Convert.ToInt32(Console.ReadLine());
            return outputNum = inputNum - 1;
        }

        private void Refresh(List<string> doc)
        {
            int i = 1;
            Console.Clear();
            Console.WriteLine($"\t \t \t Visel Editor\n");
            foreach(string line in doc)
            {
                Console.Write($"{$"ln {i}",7}│ ");
                Console.WriteLine(line);
                i++;
            }
        }
    }
}