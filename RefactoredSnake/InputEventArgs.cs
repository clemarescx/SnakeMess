using System;

namespace RefactoredSnake
{
	public class InputEventArgs : EventArgs
	{
		public ConsoleKeyInfo KeyPressed;
		public InputEventArgs(ConsoleKeyInfo key)
		{
			KeyPressed = key;
		}
		
	}
}