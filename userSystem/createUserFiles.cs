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
                Directory.SetCurrentDirectory(@"C:\Users\mario\AppData\Roaming\BetterCLuster\Users");
                DRY.Progress($"Creating Directory {USERNAME}");
                Directory.CreateDirectory(USERNAME);
                Directory.SetCurrentDirectory(USERNAME);
                DRY.Progress($"Creating Directory 'Outputs'");
                Directory.CreateDirectory("Outputs");
                DRY.Progress($"Creating Directory 'Inputs'");
                Directory.CreateDirectory("Inputs");
                DRY.Progress($"Creating Directory 'ShortCuts'");
                Directory.CreateDirectory("ShortCuts");
                DRY.Progress($"Creating Directory 'Info'");
                Directory.CreateDirectory("Info");
                Directory.SetCurrentDirectory("Info");
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
                BetterCLuster.Program.use.only.global.Global.currentLoggedUser = USERNAME;
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