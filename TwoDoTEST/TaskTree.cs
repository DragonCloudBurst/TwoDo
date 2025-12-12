using System.Collections;
using System.Collections.Generic;

namespace TwoDoTEST;

public class TaskTree : IEnumerable
{
    public static SortedSet<Task>? tasksSet { get; set; }
    public Task[] taskArray { get; set; } = tasksSet?.ToArray() ?? new Task[0];

    public TaskTree()
    {
        tasksSet = new SortedSet<Task>();    
    }
    
    public void addTask(Task? task)
    {
        tasksSet.Add(task);
        tasksSet.Append(task);
    }

    public void deleteTask(Task? task)
    {
        tasksSet.Remove(task);
    }

    public int getTaskCount()
    {
        return tasksSet.Count;
    }
    
    public TaskEnum GetEnumerator()
    {
        return new TaskEnum(taskArray);
    }
    
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
    
}