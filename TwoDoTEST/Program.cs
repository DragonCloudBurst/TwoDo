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
		 else if (userChoice == "task")
		 {
			 printTasks(tasks);
		 }
		 else if (userChoice == "jot")
		 {
			 AnsiConsole.MarkupLine("[fuchsia]Enter the task number to take notes on:[/]    ");
			 
			 bool isJotValid = false;
			 string jotNum = "";
			 
			 while (!isJotValid)
			 {
				 jotNum = Console.ReadLine();

				 if (string.IsNullOrEmpty(jotNum) || int.Parse(jotNum).GetType() != typeof(int)) 
				 {
					 isJotValid = false;
				 }
				 else
				 {
					 isJotValid = true;
				 }
			 }
			 
			 AnsiConsole.MarkupLine("[fuchsia]Enter the jot text:[/]    ");
			 
			 bool isJotTextValid = false;
			 string jotText = "";
			 
			 while (!isJotTextValid)
			 {
				 jotText = Console.ReadLine();

				 if (string.IsNullOrEmpty(jotText)) 
				 {
					 isJotTextValid = false;
				 }
				 else
				 {
					 isJotTextValid = true;
				 }
			 }

			 int numJots = getJotsPerTask(jotNum);
			 string numJotsString = numJots.ToString();
			 
			 addJot(jotNum, jotText, numJotsString);
			 
		 }
		 else if (userChoice == "sub")
		 {
			 AnsiConsole.MarkupLine("[fuchsia]Enter the task number to add a subtask to:[/]    ");
			 
			 bool isSubValid = false;
			 string subNum = "";
			 
			 while (!isSubValid)
			 {
				 subNum = Console.ReadLine();
				 int taskCounter = tasks.getTaskCount();
				 var tasksForTaskNums = new List<Task>();
				 
				 foreach (Task task in tasks)
				 {
					 tasksForTaskNums.Add(task);
				 }

				 if (string.IsNullOrEmpty(subNum) || int.Parse(subNum).GetType() != typeof(int) ) 
				 {
					 isSubValid = false;
				 }
				 else
				 {
					 isSubValid = true;
				 }
			 }
			 
			 AnsiConsole.MarkupLine("[fuchsia]Enter the jot text:[/]    ");
			 
			 bool isSubTextValid = false;
			 string subText = "";
			 
			 while (!isSubTextValid)
			 {
				 subText = Console.ReadLine();

				 if (string.IsNullOrEmpty(subText)) 
				 {
					 isSubTextValid = false;
					 AnsiConsole.MarkupLine("[fuchsia]Please enter valid text:[/]    ");
				 }
				 else
				 {
					 isSubTextValid = true;
				 }
			 }
			 
			 
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
	    AnsiConsole.MarkupLine("[fuchsia]│[/]   [grey89]☼ To create a subtask, type 'sub'[/]                 [fuchsia]│[/]");
	    AnsiConsole.MarkupLine("[fuchsia]│[/]   [grey89]☼ To take a quick note, type 'jot'[/]                [fuchsia]│[/]");
	    AnsiConsole.MarkupLine("[fuchsia]╰[/]                [fuchsia]₊˚ ✧ ━━━━⊱⋆⊰━━━━ ✧ ₊˚[/]                [fuchsia]╯[/]");  
    }

    public static void printTasks(TaskTree treeTasks)
    {
	    foreach (Task t in treeTasks)
	    {
		    AnsiConsole.MarkupLine($"[fuchsia]│[/]   [grey89]☼ {t.taskText}[/]");
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
	    return File.ReadLines("../../../tasks.txt").Count();
    }

    public static void addJot(string taskNumber, string jot, string numJotPerTask)
    {
	    StreamWriter sw = new StreamWriter("../../../jots.txt", append: true);
	    sw.Write($"\n{taskNumber}.{numJotPerTask} {jot}");
	    sw.Close();
	    
    }

    public static int getJotsPerTask(string taskNumber)
    {
	    int numJotPerTask = 0;
	    
	    StreamReader sr = new StreamReader("../../../jots.txt");
	    var stream = sr.ReadToEnd();
	    sr.Close();

	    foreach (String line in stream.Split('\n'))
	    {
		    if (line.Substring(0, line.IndexOf(".")) == taskNumber)
		    {
			    numJotPerTask++;
		    }
	    }
	    
	    return numJotPerTask;
    }

}

