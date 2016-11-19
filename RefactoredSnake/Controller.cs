using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Environment;

namespace RefactoredSnake {
	class Controller {
		private static Point ViewDims; 
		private static View _view;
		private static Model _model;

		//static Thread _inputThread;
		//private static InputListener _inputListener;
		//private static ConsoleKeyInfo _inputKey;

		public Controller() {
			_view = new View(this);
			_model = new Model();
			//_inputListener = new InputListener();
			ViewDims = new Point(_view.X, _view.Y);
		}

		public static void Main(string[] args) {

			Controller gameLogic = new Controller();

			/*
			_inputListener = new InputListener();
			gameLogic.Subscribe(_inputListener);
			_inputThread = new Thread(_inputListener.Run);
			_inputThread.Start();
			*/

			bool running = true;
			bool paused = false;

			Point newDirection = new Point();
			//view test
			_view.PaintEntities(_model.PrintBuffer);

			// Test variable for the loop;
			Point testPoint = new Point(_model.Snake.Head.Coords);
			int testX = 1;


			Stopwatch timer = new Stopwatch();
			timer.Start();

			#region Game Loop
			// gameloop start

			while (running) {

				// Read keyPressed from View 
				var input = _view.GetInputKey();
				switch (input) {
					case Command.Quit: {
							running = false;
							continue;
						}
					case Command.Pause:
						paused = !paused;
						break;
					case Command.Up:
						break;
					case Command.Right:
						break;
					case Command.Down:
						break;
					case Command.Left:
						break;

				}

				// via delegate + Events ? (Observer pattern)
				//var inputKey = Console.GetInputKey(true);
				//Console.GetInputKey(true);
				//if(Console.KeyAvailable)

				/*
				if (_inputKey.Key == ConsoleKey.Spacebar)
				{
					Console.SetCursorPosition(0, 0);
					Console.WriteLine("Key {0} was pressed {1} times", _inputKey.Key, ++pausedcount);
					paused = !paused;
				}
				*/

				if (paused || timer.ElapsedMilliseconds < 100)
					continue;

				timer.Restart();

				//calculate
				testPoint.X += testX;
				if (isOutOfBounds(testPoint)) {
					running = !false;
					continue;
				}
				else {
					_model.SnakeMoves(testPoint);

					// update
					_model.UpdatePrintableBuffer();

					//paint			
					_view.PaintEntities(_model.PrintBuffer);

					//
					_model.RefreshSnake();
				}

			}

		}


		#endregion


		private static bool isOutOfBounds(Point point)
		{
			return point.X < 0 || point.Y < 0 || point.X >= ViewDims.X || point.Y >= ViewDims.Y;

		}

		/*
		static void Initiate(InputListener listener)
		{
			_inputThread = new Thread(listener.Run);
			Subscribe(listener);
			_inputThread.Start();
		}
		*/

			/*
		private void Subscribe(InputListener listener)
		{
			listener.KeyPressed += OnKeyPressed;
		}
		*/

		/**
		public static void OnKeyPressed(object o, InputEventArgs input)
		{
			_inputKey = input.KeyPressed;
			
		}
	*/

	}
}