using System;

namespace RefactoredSnake
{
	public class InputEventArgs : EventArgs
	{
		public ConsoleKeyInfo input;
		public InputEventArgs(ConsoleKeyInfo input)
		{
			this.input = input;
		}
		
	}
}