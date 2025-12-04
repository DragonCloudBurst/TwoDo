using Spectre.Console;
using System.IO;
using TwoDoTEST;

public static class Program
{
    public static void Main(string[] args)
    {
	    
	    
		 printStartMenu();

		 string userChoice = Console.ReadLine();

		 if (userChoice == "task")
		 {
			 
		 }
		 else if (userChoice == "new")
		 {
			 
		 }
		 else if (userChoice == "jot")
		 {
			 
		 }

		

    }
    
    

    public static void printStartMenu()
    {
	    AnsiConsole.MarkupLine("[fuchsia]╭[/]               [fuchsia] ₊˚ ✧ ━━━━⊱⋆⊰━━━━ ✧ ₊˚[/]                [fuchsia]╮[/]");
	    AnsiConsole.MarkupLine("[fuchsia]│[/]                [aqua]⚞ Welcome to TwoDo! ⚟[/]                [fuchsia]│[/]");
	    AnsiConsole.MarkupLine("[fuchsia]│[/]          [aqua]What would you like TwoDo today?[/]           [fuchsia]│[/]");
	    AnsiConsole.MarkupLine("[fuchsia]│[/]                [fuchsia] ────── ⋆⋅☆⋅⋆ ──────[/]                 [fuchsia]│[/]");
	    AnsiConsole.MarkupLine("[fuchsia]│[/]   [grey89]☼ To see tasks, type 'task'[/]                       [fuchsia]│[/]");
	    AnsiConsole.MarkupLine("[fuchsia]│[/]   [grey89]☼ To create a new task, type 'new'[/]                [fuchsia]│[/]");
	    AnsiConsole.MarkupLine("[fuchsia]│[/]   [grey89]☼ To take a quick note, type 'jot'[/]                [fuchsia]│[/]");
	    AnsiConsole.MarkupLine("[fuchsia]╰[/]                [fuchsia]₊˚ ✧ ━━━━⊱⋆⊰━━━━ ✧ ₊˚[/]                [fuchsia]╯[/]");  
    }

    public static void printTasks()
    {
	    
    }

    public static TaskTree getTasks()
    {
	    StreamReader sr = new StreamReader("tasks.txt");
	    var tasksData = sr.ReadToEnd().Split('\n');

	    TaskTree tree = new TaskTree();

	    foreach (var task in tasksData)
	    {
		    int taskNum = int.Parse(task.Substring(0,task.IndexOf(".")));
		    
		    var newTask = new Task(task, taskNum);
		    tree.addTask(newTask);
	    }

	    return tree;
    }

}

