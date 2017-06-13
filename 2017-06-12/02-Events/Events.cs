using System;

public class Events
{
	private bool theState = false;

	public event Action<bool> StateChanged;

	public bool State
	{
		set
		{
			if (theState != value) 
			{
				theState = value;
				
				if (StateChanged != null)
				{
					StateChanged(value);
				}
			}
		}
	}
	
	public static void Main()
	{
		Events evts = new Events();
		
		evts.StateChanged += newState => Console.WriteLine("================");
		evts.StateChanged += PrintChange;
		evts.StateChanged += newState => Console.WriteLine("================");

		evts.State = true;
		evts.State = true;
		evts.State = true;

		evts.State = false;
	}
	
	private static void PrintChange(bool newState)
	{
		Console.WriteLine("New State : {0}", newState);
	}
}	

	
