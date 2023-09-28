using System.IO;
using Spectre.Console;
using Spectre.Console.Advanced;
using Spectre.Console.Rendering;
using Spectre.Console.Extensions;
namespace BetterCLuster.test.UI
{
    public class Experiment : ICommand
    {
        public void Execute()
        {
            Experiments.Test();
        }
    }
    internal class Experiments
    {
        public static void Test()
        {
            /*AnsiConsole.Progress()
            .AutoRefresh(false) // Turn off auto refresh
            .AutoClear(false)   // Do not remove the task list when done
            .HideCompleted(false)   // Hide tasks as they are completed
            .Columns(new ProgressColumn[] 
            {
                new TaskDescriptionColumn(),    // Task description
                new ProgressBarColumn(),        // Progress bar
                new PercentageColumn(),         // Percentage
                new RemainingTimeColumn(),      // Remaining time
                new SpinnerColumn(),            // Spinner
            })
            .Start(ctx => 
            {
                // Define tasks
                var task1 = ctx.AddTask("[green]Getting the Terminal Ready[/]");
                var task2 = ctx.AddTask("[green]Updating UI[/]");

                while(!ctx.IsFinished) 
                {
                    task1.Increment(1);
                    task2.Increment(1);
                }
            });*/
            /*AnsiConsole.Status()
            .Start("Thinking...", ctx => 
            {
                // Simulate some work
                AnsiConsole.MarkupLine("Doing some work...");
                Thread.Sleep(1000);
                
                // Update the status and spinner
                ctx.Status("Thinking some more");
                ctx.Spinner(Spinner.Known.Bounce);
                ctx.SpinnerStyle(Style.Parse("green"));

                // Simulate some work
                AnsiConsole.MarkupLine("Doing some more work...");
                Thread.Sleep(2000);
            });*/
        }
    }
}