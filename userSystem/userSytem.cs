using System;
using ScriptEx;
using System.Text;
using System.Collections.Generic;
using System.Security.Cryptography;
using createFilesAndDirectoriesForUser;
using Spectre.Console;
using LoginSystem;
using BetterCLuster.Program.use.only.ui;

namespace userSystem
{
    public class UserSystem
    {
        public string username;
        public string fullName;
        private string password;

        public void RegisterUser()
        {
            try
            {
                Console.Clear();
                List<string> infomation = new List<string>();
                UI.Header("Register to BetterCLuster", "lime");
                // GET INFO
                fullName = UI.Propmt("Full Name", "lime", "white", false);
                username = UI.Propmt("Username", "lime", "white", false);
                password = UI.Propmt("Password", "lime", "white", true);
                infomation.Add(fullName);
                infomation.Add(username);
                string passwordHash = UI.Propmt("Confirm Password", "lime", "white", true);
                if (passwordHash == password)
                {
                    Console.Write($"A new user of the name {fullName} will be created, /n a directory will be created for the user all output files created by the user will be stored there. \n Are you sure you want to create this new user(y/n): ");
                    string confirm = Console.ReadLine();
                    if (confirm == "y" || confirm == "Y")
                    {
                        // create assoicated files, directories and hash the passowrd
                        CreateFilesAndDirectoriesForUser.create(username, infomation, passwordHash);

                    }else
                    {
                        DRY.PrintError("User registration was canceled");
                        Thread.Sleep(2000);
                        Environment.Exit(0);
                    }
                }else
                {
                    DRY.PrintError("User registration failed, password didn't match");
                    Thread.Sleep(2000);
                    Environment.Exit(0);
                }
            }catch(Exception ex)
            {
                DRY.PrintError(ex.Message);
                Thread.Sleep(2000);
                Environment.Exit(0);
            }
        }

        public static void LoginUser()
        {
            Console.Clear();
            string inputUSERNAME;
            string inputPASSWORD;
            UI.Header("Welcome Back to BetterCLuster", "lime");
            inputUSERNAME = UI.Propmt("Username", "lime", "white", false);
            inputPASSWORD = UI.Propmt("Password", "lime", "white", true);

            LoginSys.Login(inputUSERNAME, inputPASSWORD);
        }
    }
}
