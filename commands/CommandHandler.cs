using ScriptEx;
using BetterCLuster.Commands.application;
using BetterCLuster.Commands.ClusterExpCommands;
using BetterCLuster.Commands.external;
using BetterCLuster.Commands.hostOS;
using BetterCLuster.application.visel;
using BetterCLuster.application.shortRun;
using BetterCLuster.application.ClusterPasswords;
using BetterCLuster.application.ProductiTracker;

namespace CommandHandlerNamespace
{
    public class CommandHandler
    {
        public Dictionary<string, ICommand> commands;

        public CommandHandler()
        {
            try
            {
                commands = new Dictionary<string, ICommand>
                {
                    {"help", new HelpCommand()},
                    {"::q", new Exit()},
                    {"cls", new Clear()},
                    {"::info", new Info()},
                    {"now", new DateAndTime()},
                    {"ls", new ListAll()},
                    {"ls -f", new ListAllFiles()},
                    {"ls -dir", new ListAllDirectories()},
                    {"ls -num -dir", new NumberOfDirectories()},
                    {"ls -num -f", new NumberOfFiles()},
                    {"ls -export", new ExportListOfFilesAndDirectories()},
                    {"mkdir -here", new MakeDirectoryInTheCurrentDirectory()},
                    {"mkdir -select", new MakeDirectoryInSelectedDirectory()},
                    {"prop -dir", new GetPropertiesOfDirectory()},
                    {"prop -f",new GetPropertiesOfFile()},
                    {"checkfor -dir",new CheckForDirectory()},
                    {"checkfor -f",new CheckForFile()},
                    {"cat",new ReadAllLinesInFile()},
                    {"cd",new ChangeDirectory()},
                    {"pwd",new DisplayCurrentDirectory()},
                    {"compare -t",new CompareText()},
                    {"del -f",new DeleteFile()},    // have to be improved [MID]
                    {"del -dir",new DeleteDirectory()}, // have to be improved [MID]
                    {"mv -f",new MoveFile()},       // have to be improved [MID]
                    {"mv -dir",new MoveDirectory()},   // have to be improved [MID]
                    {"search -f",new SearchFilesOnly()},
                    {"search -dir",new SearchDirectoriesOnly()},
                    {"search -all",new SearchAll()},
                    {"pack",new ZipFolder()},       // have to be improved [CRITICAL]
                    {"unpack",new UnzipFolder()},   // have to be improved [CRITICAL]
                    {"cmd",new CMD()},
                    {"ps",new ProcessList()},
                    {"launch -cl",new Launch_CL()},
                    {"launch -ui",new Launch_UI()},
                    {"tts -doc",new TextToSpeech_doc()},
                    {"tts -speak",new TextToSpeech_text()},
                    {"sysinfo -all",new SystemInfoAll()},
                    {"sysinfo -select",new SystemInfoSelect()},
                    {"os",new getOperatingSystem()},
                    {"usr",new UserName()},
                    {"drivers",new getExternalAndInternalDrivers()},
                    {"shr -run",new shortRun_Run()},
                    {"shr -create",new shortRun_Create()},
                    {"visel",new Visel()},
                    {"pswrd",new PswrdsCommand()},
                    {"productitracker",new ProductiTrackerCommand()},
                    {"calendar",new CalendarNow()},
                    //{"",new ()},
                    
                };
            }
            catch (Exception ex)
            {
                DRY.PrintError($"CommandHandler Exception: {ex.Message}");
            }
            
        }

        public void ExecuteCommand(string input)
        {
            foreach (var command in commands)
            {
                if (input == command.Key)
                {
                    try
                    {
                        command.Value.Execute();
                    }
                    catch (Exception ex)
                    {
                        DRY.PrintError($"Error executing command: {ex.Message}");
                    }
                    return;
                }
            }

            // Handle unknown command
            Console.WriteLine("Unknown command");
        }
    }

    public class HelpCommand : ICommand
    {
        public void Execute()
        {
            int i = 1;
            CommandHandler ch = new CommandHandler();
            foreach(string command in ch.commands.Keys)
            {
                Console.WriteLine($"{i}. {command}");
                i++;
            }
        }
    }
}