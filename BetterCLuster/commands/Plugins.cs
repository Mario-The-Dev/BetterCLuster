using System;
using BetterCLuster.Program.use.only.global;
using System.Reflection;
using ScriptEx;

namespace BetterCLuster.Commands.plugins
{
    // Define the interface that all plugins must implement
    public interface IPlugin
    {
        string GetName();
        void Run();
    }

    // Define a class for loading plugins
    public class PluginLoader
    {
        // A list to hold all loaded plugins
        private List<IPlugin> plugins;// Me : I can use this list to get the plugins loaded

        // Constructor to initialize the list
        public PluginLoader()
        {
            plugins = new List<IPlugin>();
        }

        // Method to load plugins from a specified directory
        public void LoadPlugins(string path)
        {
            try
            {
                // Load all DLL files in the specified path
                foreach (string file in Directory.GetFiles(path, "*.dll"))
                {
                    // Load the assembly
                    Assembly assembly = Assembly.LoadFrom(file);

                    // Find all types in the assembly that implement the IPlugin interface
                    foreach (Type type in assembly.GetTypes())
                    {
                        if (type.IsClass && typeof(IPlugin).IsAssignableFrom(type))
                        {
                            // Create an instance of the plugin and add it to the list
                            IPlugin plugin = Activator.CreateInstance(type) as IPlugin;
                            plugins.Add(plugin);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                DRY.PrintError(ex.Message);
            }
            
        }

        // Method to get the list of loaded plugins
        public List<IPlugin> GetPlugins()
        {
            return plugins;
        }
    }

    // A class to demonstrate how to use the PluginLoader class to load and execute plugins
    class PLuginCommands
    {
        public static void PluginsLoaderMethod()
        {
            try
            {
                PluginLoader loader = new PluginLoader();
                loader.LoadPlugins(@"E:\.BetterCLuster\.plugins");

                List<IPlugin> plugins = loader.GetPlugins();
                Dictionary<IPlugin, bool> pluginStatus = new Dictionary<IPlugin, bool>();
                foreach (IPlugin plugin in plugins)
                {
                    pluginStatus.Add(plugin, true); // Set all plugins to enabled by default
                }

                while (true)
                {
                    Console.WriteLine("Plugins:");

                    foreach (IPlugin plugin in plugins)
                    {
                        bool status = pluginStatus[plugin];
                        Console.WriteLine($"{plugin.GetName()} [{(status ? "Running..." : "Disabled")}]");
                    }

                    Console.WriteLine("Enter the name of the plugin to toggle (or 'exit' to quit):");
                    string input = Console.ReadLine();

                    if (input.ToLower() == "exit")
                    {
                        break;
                    }

                    IPlugin selectedPlugin = plugins.FirstOrDefault(p => p.GetName().Equals(input, StringComparison.OrdinalIgnoreCase));
                    if (selectedPlugin != null)
                    {
                        pluginStatus[selectedPlugin] = !pluginStatus[selectedPlugin]; // Toggle the plugin status
                    }
                    else
                    {
                        Console.WriteLine("Plugin not found.");
                    }

                    Console.WriteLine();
                }
            }
            catch (Exception ex)
            {
                DRY.PrintError(ex.Message);
            }
            
        }

        public static void PluginStatus()
        {
            try
            {
                PluginLoader loader = new PluginLoader();
                List<IPlugin> plugins = loader.GetPlugins();
                Dictionary<IPlugin, bool> pluginStatus = new Dictionary<IPlugin, bool>();

                foreach (IPlugin plugin in plugins)
                {
                    bool status = pluginStatus[plugin];
                    Console.WriteLine($"{plugin.GetName()} [{(status ? "Running..." : "Disabled")}]");
                }
            }
            catch (Exception ex)
            {
                DRY.PrintError(ex.Message);
            }
            
        }
    }

    class PluginManager
    {
        public static void PluginManagerMethod() 
        {
            if (Global.input.Contains("PluginCLuster "))
            {
                if (Global.input.Contains("--"))
                {
                    PLuginCommands.PluginsLoaderMethod();
                }else if (Global.input.Contains("-status"))
                {
                    PLuginCommands.PluginStatus();
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
    }

}