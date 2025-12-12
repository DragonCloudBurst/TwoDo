using System.Collections;

namespace TwoDoTEST;

public class TaskEnum : IEnumerator
{
    public Task[] _tasks;

    // Enumerators are positioned before the first element
    // until the first MoveNext() call.
    int position = -1;

    public TaskEnum(Task[] list)
    {
        _tasks = list;
    }

    public bool MoveNext()
    {
        position++;
        return (position < _tasks.Length);
    }

    public void Reset()
    {
        position = -1;
    }

    object IEnumerator.Current
    {
        get
        {
            return Current;
        }
    }

    public Task Current
    {
        get
        {
            try
            {
                return _tasks[position];
            }
            catch (IndexOutOfRangeException)
            {
                throw new InvalidOperationException();
            }
        }
    }
}