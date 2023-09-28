# BetterCLuster - To do - Guide
**Author: Mario-The-Dev | Update Date: 22/07/2023**

- An improved Command Handling System
- User System
- More/Improved applications
- Improved Performence
- Improved Customization opptions

# Command Handling System - [STATUS: COMPLETED]
## Improved Command Handling System for BetterCLuster

### 1. Define an interface for your commands:

```csharp
public interface ICommand
{
    void Execute();
}
```

### 2. Implement individual commands as classes that implement the `ICommand` interface. Each command can have its own logic and behavior:

```csharp
public class ListFilesCommand : ICommand
{
    public void Execute()
    {
        // Code to list files
    }
}

public class ListAllFilesCommand : ICommand
{
    public void Execute()
    {
        // Code to list all files
    }
}
```

### 3. Create a command handler class to manage and execute the commands:

```csharp
public class CommandHandler
{
    private Dictionary<string, ICommand> commands;

    public CommandHandler()
    {
        commands = new Dictionary<string, ICommand>
        {
            { "ls", new ListFilesCommand() },
            { "ls -all", new ListAllFilesCommand() }
        };
    }

    public void ExecuteCommand(string input)
    {
        foreach (var command in commands)
        {
            if (input.Contains(command.Key))
            {
                command.Value.Execute();
                return;
            }
        }

        // Handle unknown command
        Console.WriteLine("Unknown command");
    }
}
```

### 4. Finally, in your main program, you can call the `CommandHandler` to execute the appropriate command based on the input:

```csharp
public class Program
{
    static void Main()
    {
        CommandHandler commandHandler = new CommandHandler();
        
        // Get user input
        string input = GetInputFromUser();

        // Execute command
        commandHandler.ExecuteCommand(input);
    }

    static string GetInputFromUser()
    {
        // Code to get input from the user
    }
}
```
# The Ability to Add Users
Users will have the ability to create mutliple users. This feature will help organzie outputs and inputs such as shortcuts.

# PyPlugs
A Plugin System that takes python scripts as plugins. The Python Scripts can have multiple methods, the user will be prompted to enter which method should be executed.

*Command Syntax*
> pyplug

*Prompts*
> Enter the Python plugin file path:<br>
> Enter the method to execute: 

# Improved/New Applications

## New:
- Fetcher
    - A simple webscrapper to scrape only links off a website

    - 🟢 **STATUS: COMPLETE** 
    
    *Command Syntax*:

    Webscrape
    > *fetcher*
- multiShell
    - A application that could run the user inputed command in another 
    terminal such as cmd or windows powershell

    - 🔴 **STATUS: STILL IN DEVELOPMENT**

    *Command Syntax*

    Use CMD/Command Prompt
    > *mS -cmd "command here"*

    Use Windows PowerShell
    > *mS -ps "command here"*
- Shortrun
    - A shortcut system built to open applications faster and with much ease

    - 🟡 **STATUS: BETA TESTING | REQUIRES MORE DEVELOPMENT**

    *Command Syntax*
    
    To create a shortcut
    > *shr -create*

    To run/execute a shortcut
    > *shr -run*
- ClusterPasswords
    - A tool to crack, hash and generate passwords

    - 🟢 **STATUS: COMPLETE**

    To open menu
    > pswrd
## Updated:
- Visel
    - A simple Command Line Text editor

    - 🟡 **STATUS: BETA TESTING | REQUIRES MORE DEVELOPMENT**

    Open visel
    > visel


# Improved Performence
Introducing **mutli-threading** to some of the commands, optimizing commands by removing unwanted/un-used code.

🟢 **STATUS: REDUCED BOOT UP TIME**

# Improved Customization opptions

- Adding ablitiy to customize 'status bar'
- Adding ability to add custom subtitle
- Updating the ability to change font and background colour

🔴 **STATUS: All CUSTOMIZATION FEATURES ARE STILL IN DEVELOPMENT**

# New Update 1.1.0
**Authour: Mario-The-Dev | Date: 22/07/2023**

- SIEM System
- Bug Fixes
- Command Improvements
- More Applications