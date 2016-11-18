using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace RefactoredSnake
{
	class Controller
	{
		private static View _board;
		private static Model _model;
	

		public Controller()
		{
			_board = new View(this);
			_model = new Model();
			

		}

		public static void Main(string[] args)
		{
			Controller gameLogic = new Controller();
			bool running = true;

			//view test
			_board.PaintEntities(_model.Entities);
			//Console.ReadKey(true);
			// gameloop


			// Test variable for the loop;
			Point testPoint = new Point(_model.Snake.Head.Coords);
			int testX = 1;
			while (true)
			{
				//Read input

				var inputKey = Console.ReadKey(true);
				if (inputKey.Key == ConsoleKey.Escape)
					break;
				//calculate
				testPoint.X += testX;
				_model.Snake.Move(testPoint);
				//update
				_model.UpdateEntities();
				//paint			
				_board.PaintEntities(_model.Entities);

			}

		}


		void run()
		{
			while (true)
			{
				//
			}
			
		}

		void intiate()
		{
			
		}



		private void place(GameEntity entity)
		{
			Random r = new Random();
			int x = r.Next(0, _board.X);
			int y = r.Next(0, _board.Y);

		}

	}
}