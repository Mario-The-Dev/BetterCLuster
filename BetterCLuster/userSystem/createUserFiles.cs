using System;
using userSystem;
using System.Security.Cryptography;
using ScriptEx;
using System.Text;

namespace createFilesAndDirectoriesForUser
{
    public class CreateFilesAndDirectoriesForUser
    {
        public static void create(string USERNAME, List<string> infomation, string pswrd)
        {
            try
            {
                UserSystem userSystem = new UserSystem();
                DRY.Progress($"Creating Directory {USERNAME}");
                Directory.CreateDirectory($@"E:\.BetterCLuster\.users\{USERNAME}");
                Directory.SetCurrentDirectory($@"E:\.BetterCLuster\.users\{USERNAME}");
                // create user directories
                DRY.Progress($"Creating Directory shortRun.shortcuts");
                Directory.CreateDirectory($@"./shortRun.shortcuts");
                DRY.Progress($"Creating Directory outputs");
                Directory.CreateDirectory($@"./outputs");
                DRY.Progress($"Creating Directory logs");
                Directory.CreateDirectory($@"./logs");
                DRY.Progress($"Creating Directory info");
                Directory.CreateDirectory($@"./info");
                Directory.SetCurrentDirectory(@"info");
                DRY.Progress($"Creating File info");
                infomation.Add(EncryptSHA256(pswrd));
                using(StreamWriter sw = File.AppendText("infoFILE"))
                {
                    DRY.Progress($"Adding Content");
                    foreach (string item in infomation)
                    {
                        sw.WriteLine(item);
                    }
                }
            }catch(Exception ex)
            {
                DRY.PrintError(ex.Message);
                Thread.Sleep(2000);
                Environment.Exit(0);
            }
        }

        public static string EncryptSHA256(string PASSWRD)
        {
            UserSystem userSystem = new UserSystem();
            string PASSWORD = PASSWRD;
            SHA256 sHA256 = SHA256.Create();
            string data = PASSWORD;
            byte[] dataBytes = Encoding.UTF8.GetBytes(data);
            byte[] hashBytes = sHA256.ComputeHash(dataBytes);
            string hashString = Convert.ToBase64String(hashBytes);
            return hashString;
        }
    }
}