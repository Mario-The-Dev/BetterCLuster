namespace BetterCLuster.Program.use.only.global
{ 
    public class Global
    {
        // Global Varibles
        public const string version = "1.2";
        public static string date = DateTime.Now.ToString("dd-MM");
        public static string? input;
        public static string? currentLoggedUser;
        public static string? Reminder = "No Reminders";
        public static string AppDataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "BetterCLuster");        // Global Varibles
    }
}