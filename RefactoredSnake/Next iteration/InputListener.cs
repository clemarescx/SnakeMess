using System;

namespace RefactoredSnake
{
	/// <summary>
	/// Not used - contains boilerplate code for the
	/// Publisher class in a delegate-event based 
	/// Observer design pattern
	/// 
	/// </summary>
	public class InputListener
	{
		//Publisher delegate
		public delegate void InputChangeHandler(object view, InputEventArgs input);

		public event InputChangeHandler KeyPressed;


		/// <summary>
		/// Listens for keyboard keyPressed and sends it as an event
		/// to suscriber classes
		/// </summary>
		public void Run()
		{
			while (true)
			{
				if (Console.KeyAvailable)
				{
					InputEventArgs pressed = new InputEventArgs(Console.ReadKey(true));

					KeyPressed?.Invoke(this, pressed);
					//Thread.Sleep(100);
				}
			}
		}
	}
}