using System;
using System.Collections.Generic;
using Spectre.Console;

public class Task : IComparable<Task>
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

	public int CompareTo(Task other)
	{
		return this.taskText.CompareTo(other.taskText);
	}

	public string displayText()
	{
		int strLen = this.taskText.Length;
		int spacesNeeded = maxWidth - strLen;
		double spacesNeededHalf = spacesNeeded / 2;
		int spacesNeededLeftSide = 0;
		int spacesNeededRightSide = 0;


		if ((spacesNeeded / 2) % 2 != 0)
		{
			// if the number needed is odd or not an integer
			spacesNeededLeftSide = (int)(Math.Floor(spacesNeededHalf));
			spacesNeededRightSide = (int)(spacesNeededHalf + 1);
		}
		else
		{
			// if the number needed is an even integer
			spacesNeededLeftSide = (int)(spacesNeededHalf);
			spacesNeededRightSide = (int)(spacesNeededHalf);
		}

		string leftSpaces = new string(' ', spacesNeededLeftSide);
		string rightSpaces = new string(' ', spacesNeededRightSide);

		return $"[fuchsia]│[/][grey89]☼ {leftSpaces}{this.taskText}[/]{rightSpaces}[fuchsia]│[/]";
	}
	
}
