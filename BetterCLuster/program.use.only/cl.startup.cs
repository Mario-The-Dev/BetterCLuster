using System;
using BetterCLuster.Program.use.only.global;
using ScriptEx;

namespace BetterCLuster.Program.use.only.startup
{
    internal class Boot
    {
        public static void StartUp()
        {
            Console.WriteLine($"Booting up BetterCLuster {Global.Build}v{Global.version}");
            Thread.Sleep(1000);
            Console.Clear();
            DRY.PrintError("Plugins won't be loaded as the feature is currently unstable and may not function properly");
            /*DRY.Progress("Starting Plugins...");
            PluginLoader plugin = new PluginLoader();
            plugin.LoadPlugins(@"E:\.BetterCLuster\.plugins");*/
            DRY.Completed($"Boot Sucessful");
            Thread.Sleep(5000);
            Console.Clear();
        }
    }
}