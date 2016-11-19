using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RefactoredSnake {
	class View {

		private Controller gameLogic;
		public int X { get; private set; }
		public int Y { get; private set; }

		//Publisher delegate
		public delegate void InputChangeHandler(object view, InputEventArgs input);
		public event InputChangeHandler KeyPressed;

		public View(Controller controller) {
			gameLogic = controller;
			SetupBoard();
		}

		/// <summary>
		///  Starts the terminal
		/// </summary>
		private void SetupBoard()
		{
			Console.Title = "Westerdals Oslo ACT - SNAKE";

			X = Console.WindowWidth;
			Y = Console.BufferHeight;
			Console.CursorVisible = false;
		}

		/// <summary>
		/// Prints an entity in the terminal according to its
		/// properties
		/// </summary>
		/// <param name="entity"></param>
		private void PaintEntity(GameEntity entity)
		{
			Console.ForegroundColor = entity.Color;
			Console.SetCursorPosition(entity.Coords.X, entity.Coords.Y);
			Console.Write(entity.Character);
		}

		/// <summary>
		/// Prints every entity present in an entity buffer
		/// according to their respective properties 
		/// (coordinates, colour, sign)
		/// </summary>
		public void PaintEntities(List<GameEntity> entities)
		{
			foreach (var entity in entities)
			{
				PaintEntity(entity);
			}
		}

		/// <summary>
		/// Listens for keyboard keyPressed and sends it as an event
		/// to suscriber classes
		/// </summary>
		public void ListenForInput()
		{
			while (true)
			{
				if (Console.KeyAvailable)
				{
					InputEventArgs input = new InputEventArgs(Console.ReadKey(true));

					if (KeyPressed != null)
					{
						KeyPressed(this, input);
					}
				}
			}	
		}

	}
}
