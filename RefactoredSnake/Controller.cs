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
		private static Model _points;
		private static GameEntity Apple;

		public Controller()
		{
			_board = new View(this);
			_points = new Model();
			Apple = new GameEntity(40,20);

			_points.add(Apple);

		}

		public static void Main(string[] args)
		{
			Controller gameLogic = new Controller();
			bool running = true;

			//view test
			_board.PaintEntities(_points.Entities);
			Console.ReadKey(true);
			// gameloop

		}

		private void place(GameEntity entity)
		{
			Random r = new Random();
			int x = r.Next(_board.X);
			int y = r.Next(_board.Y);


		}

	}
}