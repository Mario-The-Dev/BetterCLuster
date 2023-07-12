using System;
using ScriptEx;
using BetterCLuster.Program.use.only.global;


namespace BetterCLuster.application.passwrdGen
{
    internal class passwrdGenClass
    {
        public static void passwrdGenManager()
        {
            if (Global.input.Contains("psswrd"))
            {
                if (Global.input.Contains(""))
                {
                    Generator();
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

        static void Generator()
        {
            try
            {
                Console.Write("Length of the passwrd : ");
                int lengthOfPasswrd = Convert.ToInt32(Console.ReadLine());
                DRY.Progress("PROCESSING");
                const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%&";
                Random random = new Random();
                char[] charsl = Enumerable.Repeat(chars, lengthOfPasswrd).Select(s => s[random.Next(s.Length)]).ToArray();
                Console.Write($"Your Password : ");
                foreach (char item in charsl)
                {
                    Console.Write(item);
                }
                Console.Write("\n");
            }
            catch (Exception ex)
            {
                DRY.PrintError(ex.Message);
            }
        } 
    }
}
