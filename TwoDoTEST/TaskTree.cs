using System.Collections.Generic;

namespace TwoDoTEST;

public class TaskTree
{
    public SortedSet<Task>? tasksSet { get; set; }

    public void addTask(Task? task)
    {
        tasksSet.Add(task);
    }

    public void deleteTask(Task? task)
    {
        tasksSet.Remove(task);
    }
    
}