using System;
using ScriptEx;
using createFilesAndDirectoriesForUser;
using BetterCLuster.Program.use.only.ui;
using Spectre.Console;

namespace LoginSystem
{
    public class LoginSys
    {
        public static void Login(string USERNAME, string PASSWORD)
        {
            Directory.SetCurrentDirectory(@"E:\.BetterCLuster\.users");
            if (Directory.Exists(USERNAME))
            {
                Directory.SetCurrentDirectory($@"E:\.BetterCLuster\.users\{USERNAME}\info");
                string[] infoLines = File.ReadAllLines("infoFILE");
                if (CreateFilesAndDirectoriesForUser.EncryptSHA256(PASSWORD) ==  infoLines[2])
                {
                    UI.Header("ACCESS GRANTED", "lime");
                    Thread.Sleep(500);
                    Console.Clear();
                    UI.Header($"WELCOME BACK {infoLines[1]}", "lime");
                    Thread.Sleep(500);
                    Console.Clear();
                }else
                {
                    UI.Header("ACCESS DENIED! PASSWORD INCORRECT", "red");
                    Thread.Sleep(5000);
                    Environment.Exit(0);
                }
            }else
            {
                UI.Header("! - Specified User doesn't exist, Make sure the username was spelled properly.", "red");
                Thread.Sleep(5000);
                Environment.Exit(0);
            }
        }
    }
}