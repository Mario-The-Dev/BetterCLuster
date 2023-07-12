﻿using System;
using System.IO;
using System.IO.Compression;
using BetterCLuster.Program.use.only.global;
using ScriptEx;

namespace BetterCLuster.Commands.clusterExplorer
{
    public class ListAll : ICommand
    {
        public void Execute()
        {
            string CurrentDir = Directory.GetCurrentDirectory();
            Console.WriteLine("----- Files in the current directory -----");
            string[] files = Directory.GetFiles(CurrentDir);
            foreach (string file in files)
            {
                Console.WriteLine($"{file,-80}{File.GetLastAccessTime(file),30}{File.GetCreationTime(file),30}");
            }

            Console.WriteLine("----- Directories in the current directory -----");
            string[] dirs1 = Directory.GetDirectories(CurrentDir);
            foreach (string dir1 in dirs1)
            {
                Console.WriteLine($"{dir1,-80}{Directory.GetLastAccessTime(dir1),30}{Directory.GetCreationTime(dir1),30}");
            }
        }
    }

    public class ListAllFiles : ICommand
    {
        public void Execute()
        {
            string CurrentDir = Directory.GetCurrentDirectory();
            Console.WriteLine("----- Files in the current directory -----");
            string[] files = Directory.GetFiles(CurrentDir);
            foreach (string file in files)
            {
                Console.WriteLine($"{file,-80}{File.GetLastAccessTime(file),30}{File.GetCreationTime(file),30}");
            }
        }
    }
    public class ListAllDirectories : ICommand
    {
        public void Execute()
        {
            string CurrentDir = Directory.GetCurrentDirectory();
            Console.WriteLine("----- Directories in the current directory -----");
            string[] dirs1 = Directory.GetDirectories(CurrentDir);
            foreach (string dir1 in dirs1)
            {
                Console.WriteLine($"{dir1,-80}{Directory.GetLastAccessTime(dir1),30}{Directory.GetCreationTime(dir1),30}");
            }
        }
    }

    public class NumberOfDirectories : ICommand
    {
        public void Execute()
        {
            string[] list = Directory.GetDirectories(Directory.GetCurrentDirectory());
            Console.WriteLine($"Number of directories in the current Directory({Directory.GetCurrentDirectory()}) = {list.Length}");
        }
    }
    public class NumberOfFiles : ICommand
    {
        public void Execute()
        {
            string[] list = Directory.GetFiles(Directory.GetCurrentDirectory());
            Console.WriteLine($"Number of Files in the current Directory({Directory.GetCurrentDirectory()}) = {list.Length}");
        }
    }

    public class ExportListOfFilesAndDirectories : ICommand
    {
        public void Execute()
        {
            string CurrentDir = Directory.GetCurrentDirectory();
            using (StreamWriter sw = File.AppendText(@"E:\.BetterCLuster\.outputs\lsExport.txt"))
            {
                sw.WriteLine("----- Files in the current directory -----");
                string[] files = Directory.GetFiles(CurrentDir);
                foreach (string file in files)
                {
                    sw.WriteLine($"{file,-80}{File.GetLastAccessTime(file),30}{File.GetCreationTime(file),30}");
                }

                sw.WriteLine("----- Directories in the current directory -----");
                string[] dirs1 = Directory.GetDirectories(CurrentDir);
                foreach (string dir1 in dirs1)
                {
                    sw.WriteLine($"{dir1,-80}{Directory.GetLastAccessTime(dir1),30}{Directory.GetCreationTime(dir1),30}");
                }
            }
            
        }
    }

    public class MakeDirectoryInTheCurrentDirectory : ICommand
    {
        public void Execute()
        {
            string? inputDirName;
            string CurrentDir = Directory.GetCurrentDirectory();
            Console.Write("Name the Directory to be made :");
            inputDirName = Console.ReadLine();

            string combine = CurrentDir + @"\" + inputDirName;
            Directory.CreateDirectory(combine);
            Console.WriteLine("Directory : " + combine);
        }
    }

    public class MakeDirectoryInSelectedDirectory : ICommand
    {
        public void Execute()
        {
            string? inputDirName;
            string? inputDir;
            Console.Write("Name the Directory to be made :");
            inputDirName = Console.ReadLine();

            Console.Write("Where should the New Direcotry be made :");
            inputDir = Console.ReadLine();

            string combine = inputDir + @"\" + inputDirName;
            Directory.CreateDirectory(combine);
            Console.WriteLine("Directory : " + combine);
        }
    }

    public class GetPropertiesOfDirectory : ICommand
    {
        public void Execute()
        {
            string? inputDir;
            Console.Write("Directory name : ");
            inputDir = Console.ReadLine();

            DirectoryInfo dirInfo = new DirectoryInfo(inputDir);
            if (dirInfo.Exists)
            {
                Console.WriteLine($"Directory Name : {dirInfo.Name}");
                Console.WriteLine($"Full Path of the directory : {dirInfo.FullName}");
                Console.WriteLine($"Creation Time : {dirInfo.CreationTime}");
                Console.WriteLine($"Last modified time : {dirInfo.LastWriteTime}");
                Console.WriteLine($"Last Accessed time : {dirInfo.LastAccessTime}");
            }
            else
            {
                Console.WriteLine("File not found");
            }
        }
    }

    public class GetPropertiesOfFile: ICommand
    {
        public void Execute()
        {
            string? inputFile;
            Console.Write("File name : ");
            inputFile = Console.ReadLine();

            FileInfo fileInfo = new FileInfo(inputFile);
            if (fileInfo.Exists)
            {
                Console.WriteLine($"File Name : {fileInfo.Name}");
                Console.WriteLine($"File Extention : {fileInfo.Extension}");
                Console.WriteLine($"Full Path of the directory/file : {fileInfo.FullName}");
                Console.WriteLine($"File Size in bytes : {fileInfo.Length}");
                Console.WriteLine($"Creation Time : {fileInfo.CreationTime}");
                Console.WriteLine($"Last modified time : {fileInfo.LastWriteTime}");
                Console.WriteLine($"Last Accessed time : {fileInfo.LastAccessTime}");
            }
            else
            {
                Console.WriteLine("File not found");
            }
        }
    }

    public class CheckForDirectory : ICommand
    {
        public void Execute()
        {
            string inputDir;
            Console.Write("Directory name : ");
            inputDir = Console.ReadLine();

            string[] directories = Directory.GetDirectories(Directory.GetCurrentDirectory(), $"*{inputDir}*.*", SearchOption.TopDirectoryOnly);
            foreach (string directory in directories)
            {
                Console.WriteLine(directory);
            }
            Console.WriteLine($"\nFound {directories.Length} Directories with the keyword '{inputDir}'");
        }
    }

    public class CheckForFile : ICommand
    {
        public void Execute()
        {
            string inputFile;
            Console.Write("File name : ");
            inputFile = Console.ReadLine();

            string[] files = Directory.GetFiles(Directory.GetCurrentDirectory(), $"*{inputFile}*.*", SearchOption.TopDirectoryOnly);
            foreach (string file in files)
            {
                Console.WriteLine(file);
            }
            Console.WriteLine($"\nFound {files.Length} Files with the keyword '{inputFile}'");
        }
    }

    public class ReadAllLinesInFile : ICommand
    {
        public void Execute()
        {
            string inputFile;
            Console.Write("Enter file : ");
            inputFile = Console.ReadLine();

            string[] lines = File.ReadAllLines(inputFile);

            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }
        }
    }

    public class ChangeDirectory : ICommand
    {
        public void Execute()
        {
            string inputDir;
            Console.Write("Enter Direcotry : ");
            inputDir = Console.ReadLine();
            if (Directory.Exists(inputDir))
            {
                Directory.SetCurrentDirectory(inputDir);
                Console.WriteLine($"Switched to '{inputDir}'");
            }
            else
            {
                Console.WriteLine($"Directory provided '{inputDir}' doesn't exist");
            }
            //change directory
        }
    }

    public class DisplayCurrentDirectory : ICommand
    {
        public void Execute()
        {
            string CurrentDir = Directory.GetCurrentDirectory();
            Console.WriteLine(CurrentDir);
        }
    }

    public class DeleteFile : ICommand
    {
        public void Execute()
        {
            Console.Write("File to be deleted : ");
            string inputFile = Console.ReadLine();
            bool delete;
            if (File.Exists(inputFile))
            {
                Console.Write("Are you sure you want to permenatly delete this file(true/false) : ");
                delete = Convert.ToBoolean(Console.ReadLine());
                if (delete == true)
                {
                    File.Delete(inputFile);
                    Console.WriteLine($"The File was deleted {inputFile}");
                } else
                {
                    Console.WriteLine($"The file was not deleted {inputFile}");
                }

            } else
            {
                DRY.PrintError("File was not found");
            }
        }
    }

    public class DeleteDirectory : ICommand
    {
        public void Execute()
        {
            Console.Write("Enter name of Directory : ");
            string inputDir = Console.ReadLine();
            bool delete;
            if (Directory.Exists(inputDir))
            {
                Console.Write($"Are you sure you want to permenatly delete {inputDir} and the files in the directory?(true/false) : ");
                delete = Convert.ToBoolean(Console.ReadLine());
                if (delete == true)
                {
                    Directory.Delete(inputDir, true);
                    Console.WriteLine("Directory was deleted");
                } else
                {
                    Console.WriteLine($"{inputDir} was not deleted");
                }
            } else
            {
                DRY.PrintError("Directory not found");
            }
        }
    }

    public class MoveFile : ICommand
    {
        public void Execute()
        {
            Console.Write("Enter the file to be moved : ");
            string src = Console.ReadLine();
            Console.Write("Directory the file should be moved to : ");
            string target = Console.ReadLine();

            if (File.Exists(src))
            {
                if (Directory.Exists(target))
                {
                    File.Move(src, target);
                } else
                {
                    DRY.PrintError("Directory does not exist");
                }
            } else
            {
                DRY.PrintError("File does not exist");
            }
        }
    }

    public class MoveDirectory : ICommand
    {
        public void Execute()
        {
            Console.Write("Enter the directory to be moved : ");
            string src = Console.ReadLine();

            if (Directory.Exists(src))
            {
                Console.Write("Directory the directory should be moved to : ");
                string target = Console.ReadLine();

                if (Directory.Exists(target))
                {
                    Directory.Move(src, target);
                } else
                {
                    DRY.PrintError("Traget directory does not exist");
                    //Cannot create 'c:\example' because a file or directory with the same name already exists.
                }
            } else
            {
                DRY.PrintError("Source direcotry does not exist");
            }
        }
    }

    public class SearchFilesOnly : ICommand
    {
        public void Execute()
        {
            Console.Write("File Name : ");
            string inputFile = Console.ReadLine();
            DRY.Progress("Searching...");
            string[] files = Directory.GetFiles(Directory.GetCurrentDirectory(), $"*{inputFile}*.*", SearchOption.AllDirectories);
            DRY.Progress("Grabing Files...");
            foreach (string file in files)
            {
                Console.WriteLine($"{file,-80}{File.GetLastAccessTime(file),30}{File.GetCreationTime(file),30}");
            }
            Console.WriteLine($"\nFound {files.Length} Files with the keyword '{inputFile}'");
        }
    }

    public class SearchDirectoriesOnly : ICommand
    {
        public void Execute()
        {
            Console.Write("Directory Name : ");
            string inputDir = Console.ReadLine();
            DRY.Progress("Grabing Directories...");
            string[] directories = Directory.GetDirectories(Directory.GetCurrentDirectory(), $"*{inputDir}*.*", SearchOption.AllDirectories);
            foreach (string directory in directories)
            {
                Console.WriteLine($"{directory,-80}{Directory.GetLastAccessTime(directory),30}{Directory.GetCreationTime(directory),30}");
            }
            Console.WriteLine($"\nFound {directories.Length} Directories with the keyword '{inputDir}'");
        }
    }

    public class SearchAll : ICommand
    {
        public void Execute()
        {
             Console.Write("Keyword : ");
            string Input = Console.ReadLine();
            DRY.Progress("Searching...");
            DRY.Progress("Grabing Directories...");
            Console.WriteLine("Directories");
            string[] directories = Directory.GetDirectories(Directory.GetCurrentDirectory(), $"*{Input}*.*", SearchOption.AllDirectories);
            foreach (string directory in directories)
            {
                Console.WriteLine($"{directory,-80}{Directory.GetLastAccessTime(directory),30}{Directory.GetCreationTime(directory),30}");
            }
            DRY.Progress("Grabing Files...");
            Console.WriteLine("Files");
            string[] files = Directory.GetFiles(Directory.GetCurrentDirectory(), $"*{Input}*.*", SearchOption.AllDirectories);
            foreach (string file in files)
            {
                Console.WriteLine($"{file,-80}{File.GetLastAccessTime(file),30}{File.GetCreationTime(file),30}");
            }

            Console.WriteLine($"\nFound {files.Length} Files with the keyword '{Input}'");
            Console.WriteLine($"\nFound {directories.Length} Directories with the keyword '{Input}'");
        }
    }

    public class ZipFolder : ICommand
    {
        public void Execute()
        {
            Console.Write("Source Directory : ");
            string? srcDirectoryName = Console.ReadLine();
            Console.Write("Destination Directory : ");
            string? destinationArchiveFileName = Console.ReadLine();
            ZipFile.CreateFromDirectory(srcDirectoryName, destinationArchiveFileName);
        }
    }

    public class UnzipFolder : ICommand
    {
        public void Execute()
        {
            Console.Write("Source Directory : ");
            string? srcArchiveFileName = Console.ReadLine();
            Console.Write("Destination Directory : ");
            string? destinationDirectoryName = Console.ReadLine();
            ZipFile.ExtractToDirectory(srcArchiveFileName, destinationDirectoryName);
        }
    }
}
