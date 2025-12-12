using System.Collections;
using System.Collections.Generic;

namespace TwoDoTEST;

public class TaskTree : IEnumerable
{
    public static SortedSet<Task>? tasksSet { get; set; }
    public List<Task>? taskList { get; set; }

    public TaskTree()
    {
        tasksSet = new SortedSet<Task>(); 
        taskList = new List<Task>();

        foreach (Task task in tasksSet)
        {
            taskList.Add(task);
        }
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
        return new TaskEnum(taskList.ToArray());
    }
    
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
    
}