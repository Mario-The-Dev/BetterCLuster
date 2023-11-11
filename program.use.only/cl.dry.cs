namespace ScriptEx
{
    //Don't Repeat Yourself
    class DRY
    {
        public static void PrameterException(){
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Prameter(s) cannot be executed or the prameters are null");
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void PrintError(string Error){
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[!] {Error}");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void Debug(string Progress){
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"[*] {Progress}");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void Progress(string Progress){
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"[-] {Progress}");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void Completed(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"[+] {msg}");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void TypeingAnimation(string text, int speed)
        {
            foreach (char char1 in text)
            {
                Console.Write(char1);
                Thread.Sleep(speed);
            }
        }
    }
}