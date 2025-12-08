using System.Collections;
using Spectre.Console;
using System.IO;
using TwoDoTEST;

public static class Program
{
    public static void Main(string[] args)
    {
	    var tasks = getTasks();
	    
		 printStartMenu();

		 string userChoice = Console.ReadLine();

		 if (userChoice == "new")
		 {
			 AnsiConsole.MarkupLine("[fuchsia]Enter task text:[/]    ");

			 bool isTaskValid = false;
			 string taskText = "";
			 while (!isTaskValid)
			 {
				 taskText = Console.ReadLine();

				 if (string.IsNullOrEmpty(taskText))
				 {
					 isTaskValid = false;
				 }
				 else
				 {
					 isTaskValid = true;
				 }
			 }
			 
			 // calc next task num here

			 int numOfTasks = getNumOfTasks();
			 int nextTaskNum = numOfTasks + 1;
			 
			 tasks.addTask(new Task(taskText, nextTaskNum));

			 StreamWriter sw = new StreamWriter("../../../tasks.txt", append: true);
			 sw.Write($"\n{tasks.getTaskCount()}. {taskText}");
			 sw.Close();
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

    public static void printTasks(TaskTree treeTasks)
    {
	    int numOfTasks = treeTasks.getTaskCount();

	    var tasksEnum = treeTasks.tasksSet.GetEnumerator();

	    for (int i = 0; i < numOfTasks; i++)
	    {
		    AnsiConsole.MarkupLine($"[fuchsia]│[/]   [grey89]☼ {tasksEnum.Current.taskNum}. {tasksEnum.Current.taskText}[/]");
		    tasksEnum.MoveNext();
	    }
    }

    public static TaskTree getTasks()
    {
	    StreamReader sr = new StreamReader("../../../tasks.txt");
	    var tasksData = new List<String>();
	    try
	    {
		    var stream = sr.ReadToEnd();

		    foreach (String line in stream.Split('\n'))
		    {
			    tasksData.Add(line);
		    }
		    
		    
	    }
	    catch (Exception e)
	    {
		    Console.WriteLine(e);
		    throw;
	    }
	    
	    sr.Close();

	    TaskTree tree = new TaskTree();

	    foreach (var task in tasksData)
	    {
		    int taskNum = int.Parse(task.Substring(0,task.IndexOf(".")));
		    
		    var newTask = new Task(task, taskNum);
		    tree.addTask(newTask);
	    }

	    return tree;
    }

    public static int getNumOfTasks()
    {
	    //StreamReader sr = new StreamReader("../../../tasks.txt");
	    
	    return File.ReadLines("../../../tasks.txt").Count();
    }

}

