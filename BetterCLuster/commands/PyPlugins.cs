using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using BetterCLuster.Program.use.only.ui;
using ScriptEx;

namespace BetterCLuster.Commands.PyPlugsSys
{
    public class PyPlugs : ICommand
    {
        public void Execute()
        {
            PythonPluginSystem pluginSystem = new PythonPluginSystem();
            string scriptPath = UI.Propmt("Enter the Python plugin file path", "cyan", "white", false);
            pluginSystem.LoadPlugin(scriptPath);
            string methodName = UI.Propmt("Enter the method to execute(Case Sensitive)", "cyan", "white", false);
            DRY.Progress($"Executing method '{methodName}' from plugin '{Path.GetFileName(scriptPath)}':");
            pluginSystem.ExecuteMethod(methodName);
        }
    }

    public class PythonPluginSystem
    {
        private ScriptEngine engine;
        private ScriptScope scope;

        public PythonPluginSystem()
        {
            engine = Python.CreateEngine();
            scope = engine.CreateScope();
        }

        public void LoadPlugin(string pluginPath)
        {
            try
            {
                engine.ExecuteFile(pluginPath, scope);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading plugin '{pluginPath}': {ex.Message}");
            }
        }

        public void ExecuteMethod(string methodName)
        {
            try
            {
                dynamic method = scope.GetVariable(methodName);
                method();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error executing method '{methodName}': {ex.Message}");
            }
        }
    }
}