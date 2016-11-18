using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactoredSnake {
	class View {

		private Controller gameLogic;
		public int X { get; private set; }
		public int Y { get; private set; }

		public View(Controller controller) {
			gameLogic = controller;
			SetupBoard();
		}

		private void SetupBoard()
		{
			Console.Title = "Westerdals Oslo ACT - SNAKE";

			X = Console.WindowWidth;
			Y = Console.BufferHeight;
			Console.CursorVisible = false;
		}

		private void PaintEntity(GameEntity entity)
		{
			Console.ForegroundColor = entity.Color;
			Console.SetCursorPosition(entity.Coords.X, entity.Coords.Y);
			Console.Write(entity.Character);
		}

		//TODO
		/// <summary>
		/// Prints every entity according to their respective
		/// properties (coordinates, colour, sign)
		/// </summary>
		public void PaintEntities(List<GameEntity> entities)
		{
			Console.Clear();
			//
			foreach (var entity in entities)
			{
				PaintEntity(entity);
			}
		}
		

	}
}
