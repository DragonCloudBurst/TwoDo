using Spectre.Console;

public class Task
{
    public string taskText { get; set; }
    public int taskNum { get; set; }
    public List<string>? taskNotes { get; set; }

    static int maxWidth = 55;

    public Task(string text, int num)
    {
        this.taskText = text;
	this.taskNum = num;
	this.taskNotes = null;
    }

    public string displayText()
    {
	int strLen = this.taskText.Length;
	int spacesNeeded = maxWidth - strLen;
	int spacesNeededLeftSide = 0;
	int spacesNeededRightSide = 0;

        
	if ((spacesNeeded / 2) % 2 != 0)
	{
	    // if the number needed is odd or not an integer
            spacesNeededLeftSide = Math.Floor(spacesNeeded / 2);
	    spacesNeededRightSide = (spacesNeeded / 2) + 1;
	}
	else
	{
	    // if the number needed is an even integer
	    spacesNeededLeftSide = spacesNeeded / 2;
	    spacesNeededRightSide = spacesNeeded / 2;
	}

	return $"[fuchsia]│[/][grey89]☼ {" " * spacesNeededLeftSide}{this.taskText}[/]{" " * spacesNeededRightSide}[fuchsia]│[/]");
    }

}
