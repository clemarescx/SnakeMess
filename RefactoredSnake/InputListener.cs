using System;
using System.Threading;

namespace RefactoredSnake
{
	public class InputListener
	{
		//Publisher delegate
		public delegate void InputChangeHandler(object view, InputEventArgs input);
		public event InputChangeHandler KeyPressed;


		/// <summary>
		/// Listens for keyboard keyPressed and sends it as an event
		/// to suscriber classes
		/// </summary>
		public void Run() {
			while (true)
			{
				//Thread.Sleep(100);
				if (Console.KeyAvailable)
				{
					InputEventArgs Pressed = new InputEventArgs(Console.ReadKey(true));

					if (KeyPressed != null)
					{
						KeyPressed(this, Pressed);
					}
				}
				
			}

		}


	}
}