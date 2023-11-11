using System;
using ScriptEx;
using System.Security.Cryptography;
using BetterCLuster.Program.use.only.global;
using BetterCLuster.Program.use.only.ui;
using System.Text;
using Spectre.Console;

namespace BetterCLuster.application.ClusterPasswords
{
    public class PswrdsCommand : ICommand
    {
        public void Execute()
        {
            PasswordOptions passwordOptions = new PasswordOptions();
            passwordOptions.Prompt();
        }
    }

    public class PasswordOptions
    {
        public void Prompt()
        {
            //UI.HugeText("CLusterPassowrds v1.0.1", Spectre.Console.Color.Orange1, "center");
            List<string> options = new List<string>() {"Generate a Password", "Hash a Passoword", "BruteForce a Password", "Make a list", "Exit"};
            while (true)
            {
                string selectedOptions = UI.SelectionPrompt("[white bold]CLusterPassowrds v1.0.1[/]", options);

                if (selectedOptions == "Generate a Password")
                {
                    GeneratePassowrdPrompt();
                    break;
                }else if (selectedOptions == "Make a list")
                {
                    GenerateList(Convert.ToInt32(UI.Propmt("Number of Passwords", "cyan", "white", false)), Convert.ToInt32(UI.Propmt("Length of a Password", "cyan", "white", false)), UI.Propmt("Path to the text file(E:\\pswrd.txt)", "cyan", "white", false));
                    break;
                }else if (selectedOptions == "Hash a Passoword")
                {
                    HashPassowrdPrompt();
                    break;
                }else if (selectedOptions == "BruteForce a Password")
                {
                    List<string> opp = new List<string>() {"Guess", "Use a List"};
                    string option = UI.SelectionPrompt("Choose Hashing Algorithm", opp);
                    if (option == "Guess")
                    {
                        GuessCrackerPrompt();
                    }else if(option == "Use a List")
                    {
                        CrackerPrompt();
                    }
                    break;
                }else if (selectedOptions == "Exit")
                {
                    break;
                }else
                {
                    DRY.PrintError("The option isn't supported or doesn't exist");
                }
            }
        }

        private static string GeneratePassword(int length)
        {
            //Random random1 = new Random();//remove
            //int rn = random1.Next(4, 15);//remove
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%&";//ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%&
            Random random = new Random();
            return new string(Enumerable.Repeat(chars, length)//10
            .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private static string EncryptSHA256(int length)
        {
            SHA256 sHA256 = SHA256.Create();
            string data = GeneratePassword(length);
            byte[] dataBytes = Encoding.UTF8.GetBytes(data);
            byte[] hashBytes = sHA256.ComputeHash(dataBytes);
            string hashString = Convert.ToBase64String(hashBytes);
            return hashString;
        }

        public static void GenerateList(int num, int lengthOfPasswrd, string path)
        {
            using (StreamWriter sw = File.AppendText(path))
            {
                for (int i = 0; i < num; i++)
                {
                    Console.WriteLine($"Password Generated {GeneratePassword(lengthOfPasswrd)} || Password(s) generated = {i} || Encypted(SHA256) = {EncryptSHA256(lengthOfPasswrd)}");
                    sw.WriteLine(GeneratePassword(lengthOfPasswrd));
                }
            }
        }


        static void GeneratePassowrdPrompt()
        {
            UI.Header("Generate a Passoword", "lime");
            int lengthOfPasswrd = Convert.ToInt32(UI.Propmt("Length of the Password", "cyan", "white", false));
            DRY.Progress("PROCESSING");
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%&";
            Random random = new Random();
            char[] charsl = Enumerable.Repeat(chars, lengthOfPasswrd).Select(s => s[random.Next(s.Length)]).ToArray();
            Console.Write($"Your Password : ");
            foreach (char item in charsl)
            {
                Console.Write(item);
            }
            Console.WriteLine("\n");
        }

        static void HashPassowrdPrompt()
        {
            UI.Header("Hash a Password", "lime");
            string? password = UI.Propmt("Password to be Hashed", "cyan", "white", false);

            List<string> hashingAlgs = new List<string>() {"SHA256", "MD5"};
            string hashingAlg = UI.SelectionPrompt("Choose Hashing Algorithm", hashingAlgs);

            if (hashingAlg == "SHA256")
            {
                SHA256 sHA256 = SHA256.Create();
                string data = password;
                byte[] dataBytes = Encoding.UTF8.GetBytes(data);
                byte[] hashBytes = sHA256.ComputeHash(dataBytes);
                string hashString = Convert.ToBase64String(hashBytes);
                Console.WriteLine($"The Hash of {password} = {hashString} | SHA256");
            }else if (hashingAlg == "MD5")
            {
                MD5 mD5 = MD5.Create();
                string data = password;
                byte[] dataBytes = Encoding.UTF8.GetBytes(data);
                byte[] hashBytes = mD5.ComputeHash(dataBytes);
                string hashString = Convert.ToBase64String(hashBytes);
                Console.WriteLine($"The Hash of {password} = {hashString} | MD5");
            }else
            {
                DRY.PrintError("The Hashing algorithm isn't supported or doesn't exist");
            }
            DRY.PrintError("End of Session");
        }

        static void GuessCrackerPrompt()
        {
            UI.Header("Guess a Password", "lime");
            string? Hashedpassword = UI.Propmt("Hashed Password", "cyan", "white", false);
            string? newPassword = UI.Propmt("Guess Password", "cyan", "white", false);
            List<string> hashingAlgs = new List<string>() {"SHA256", "MD5"};
            string hashingAlg = UI.SelectionPrompt("Choose Hashing Algorithm", hashingAlgs);

            if (hashingAlg == "SHA256")
            {
                int i = 1;
                string pswrd = newPassword;

                if (SHA256_BruteForce(pswrd, Hashedpassword, i) == false)
                {
                    //SHA256_BruteForce(pswrd, Hashedpassword, i);
                    i++;
                }else
                {

                }

            }else if (hashingAlg == "MD5")
            {
                int i = 1;
                string pswrd = newPassword;

                if (MD5_BruteForce(pswrd, Hashedpassword, i) == false)
                {
                    //MD5_BruteForce(pswrd, Hashedpassword, i);
                    i++;
                }else
                {

                }

            }else
            {
                DRY.PrintError("The Hashing algorithm isn't supported or doesn't exist");
            }
            DRY.PrintError("End of Session");
        }

        // Tables!!!!!

        static void CrackerPrompt()
        {
            UI.Header("Crack a Password", "lime");
            string? Hashedpassword = UI.Propmt("Hashed Password", "cyan", "white", false);

            List<string> hashingAlgs = new List<string>() {"SHA256", "MD5"};
            string hashingAlg = UI.SelectionPrompt("Choose Hashing Algorithm", hashingAlgs);

            List<string> lists = new List<string>(Directory.GetFiles(@$"C:\Users\mario\AppData\Roaming\BetterCLuster\Users\{Global.currentLoggedUser}\Inputs"));
            string list = UI.SelectionPrompt("Choose Password List", lists);

            if (hashingAlg == "SHA256")
            {
                int i = 1;
                string[] pswrds = File.ReadAllLines(list);
                foreach (string pswrd in pswrds)
                {
                    if (SHA256_BruteForce(pswrd, Hashedpassword, i) == false)
                    {
                        //SHA256_BruteForce(pswrd, Hashedpassword, i);
                        i++;
                    }else
                    {
                        break;
                    }
                }
            }else if (hashingAlg == "MD5")
            {
                int i = 1;
                string[] pswrds = File.ReadAllLines(list);
                foreach (string pswrd in pswrds)
                {
                    if (MD5_BruteForce(pswrd, Hashedpassword, i) == false)
                    {
                        MD5_BruteForce(pswrd, Hashedpassword, i);
                        i++;
                    }else
                    {
                        break;
                    }
                }
            }else
            {
                DRY.PrintError("The Hashing algorithm isn't supported or doesn't exist");
            }
            DRY.PrintError("End of Session");
        }

        static bool SHA256_BruteForce(string newPassword /*The Password that will be matched with --> this password*/ , string hashedPassowrd, int i)
        {
            string hash = hashedPassowrd;
            SHA256 sHA256 = SHA256.Create();
            string data = newPassword;
            byte[] dataBytes = Encoding.UTF8.GetBytes(data);
            byte[] hashBytes = sHA256.ComputeHash(dataBytes);
            string hashString = Convert.ToBase64String(hashBytes);

            // Col = No. | Status | Password Generated | Hash | Provided Hash

            var table = new Table();
            table.AddColumn("No.");
            table.AddColumn("Status");
            table.AddColumn("Password Generated");
            table.AddColumn("Hash");
            table.AddColumn("Provided Hash");
            table.AddColumn("Algorithm");
            table.HideHeaders();


            if (hashString == hash)
            {
                // DRY.Completed($"Password Matches || {newPassword} || HASH(Given) = {hash}");
                table.AddRow($"{i}", "[green]Matches[/]", newPassword, hashString, hash, "SHA256");
                AnsiConsole.Write(table);
                Console.ReadKey();
                table.Rows.Clear();
                return true;
            }else if (hashString != hash)
            {
                table.AddRow($"{i}", "[red]Does not Match[/]", newPassword, hashString, hash, "SHA256");
                // DRY.PrintError($"Doesn't match '{newPassword}' || Hash string for '{newPassword}' : {hashString} || {i} || Hash(Given) = {hash} || SHA256");
                AnsiConsole.Write(table);
                table.Rows.Clear();
                return false;
            }
            return false;
        }

        static bool MD5_BruteForce(string newPassword /*The Password that will be matched with --> this password*/ , string hashedPassowrd, int i)
        {
            string hash = hashedPassowrd;
            MD5 mD5 = MD5.Create();
            string data = newPassword;
            byte[] dataBytes = Encoding.UTF8.GetBytes(data);
            byte[] hashBytes = mD5.ComputeHash(dataBytes);
            string hashString = Convert.ToBase64String(hashBytes);

            if (hashString == hash)
            {
                DRY.Completed($"Password Matches || {newPassword} || HASH = {hash}");
                Console.ReadKey();
                return true;
            }else if (hashString != hash)
            {
                DRY.PrintError($"Doesn't match '{newPassword}' || Hash string for '{newPassword}' : {hashString} || {i} || Hash(Given) = {hash} || MD5");
                return false;
            }

            return false;
        }
    }
}