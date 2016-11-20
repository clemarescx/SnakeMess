using System;

namespace RefactoredSnake
{
	/// <summary>
	/// Not used - contains boilerplate code for input
	/// events in a delegate-event based Observer pattern
	/// 
	/// </summary>
	public class InputEventArgs : EventArgs
	{
		public ConsoleKeyInfo KeyPressed;
		public InputEventArgs(ConsoleKeyInfo key)
		{
			KeyPressed = key;
		}
		
	}
}