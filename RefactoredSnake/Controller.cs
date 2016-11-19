using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RefactoredSnake {
	class Controller {
		private static Point ViewDims; 
		private static View _view;
		private static Model _model;

		static Thread _inputThread;

		private static ConsoleKey _key;

		public Controller() {
			_view = new View(this);
			_model = new Model();
			ViewDims = new Point(_view.X, _view.Y);
		}

		public static void Main(string[] args) {

			Controller gameLogic = new Controller();
			bool running = true;

			//view test
			_view.PaintEntities(_model.PrintBuffer);
			//Console.ReadKey(true);


			// Test variable for the loop;
			Point testPoint = new Point(_model.Snake.Head.Coords);
			int testX = 1;

			Initiate();


			Stopwatch timer = new Stopwatch();
			timer.Start();
			// gameloop
			while (running) {

				// Read keyPressed from View 
				// via delegate + Events ? (Observer pattern)
				if (timer.ElapsedMilliseconds < 100) continue;
				timer.Restart();
				//var inputKey = Console.ReadKey(true);
				//Console.ReadKey(true);
				if (_key == ConsoleKey.Escape)
				{
					Console.WriteLine("ARHGHRHKGFH");
					Console.ReadKey(true);
					running = Quit();
				}
					
				
				//calculate
				testPoint.X += testX;
				_model.snakeMoves(testPoint);
				
				//update
				_model.UpdatePrintableBuffer();
				//paint			
				_view.PaintEntities(_model.PrintBuffer);
				_model.refreshSnake();

			}

		}

		private static bool Quit()
		{
			//_inputThread.Join();
			return false;
		}


		void run() {
			
		}

		static void Initiate()
		{
			
			_inputThread = new Thread(_view.ListenForInput);
		}

		private void place(PrintableEntity entity) {
			Random r = new Random();
			int x = r.Next(0, _view.X);
			int y = r.Next(0, _view.Y);

		}

		private void Suscribe()
		{
			_view.KeyPressed += OnKeyPressed;
		}

		public void OnKeyPressed(object o, InputEventArgs input)
		{
			Console.WriteLine("Key {0} was pressed", input.KeyPressed);
			_key = input.KeyPressed.Key;
		}

	}
}