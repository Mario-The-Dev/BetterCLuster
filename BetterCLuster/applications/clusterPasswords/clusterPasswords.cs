using System;
using ScriptEx;
using System.Security.Cryptography;
using BetterCLuster.Program.use.only.global;
using BetterCLuster.Program.use.only.ui;
using System.Text;

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
            UI.HugeText("CLusterPassowrds v1.0.1", Spectre.Console.Color.Orange1, "center");
            List<string> options = new List<string>() {"Generate a Password", "Hash a Passoword", "BruteForce a Password", "Exit"};
            while (true)
            {
                string selectedOptions = UI.SelectionPrompt("Choose a Function", options);

                if (selectedOptions == "Generate a Password")
                {
                    GeneratePassowrdPrompt();
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
        static void CrackerPrompt()
        {
            UI.Header("Crack a Password", "lime");
            string? Hashedpassword = UI.Propmt("Hashed Password", "cyan", "white", false);

            List<string> hashingAlgs = new List<string>() {"SHA256", "MD5"};
            string hashingAlg = UI.SelectionPrompt("Choose Hashing Algorithm", hashingAlgs);

            List<string> lists = new List<string>(Directory.GetFiles(@"E:\.BetterCLuster\.passwrdLists"));
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

            if (hashString == hash)
            {
                DRY.Completed($"Password Matches || {newPassword} || HASH(Given) = {hash}");
                Console.ReadKey();
                return true;
            }else if (hashString != hash)
            {
                DRY.PrintError($"Doesn't match '{newPassword}' || Hash string for '{newPassword}' : {hashString} || {i} || Hash(Given) = {hash} || SHA256");
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