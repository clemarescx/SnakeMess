using System;
using System.Diagnostics;

namespace RefactoredSnake
{
	internal class Controller
	{
		private static Point _viewDims;
		private static View _view;
		private static Model _model;

		public Controller()
		{
			_view = new View(this);
		}

		public static void Main(string[] args)
		{
			var gameLogic = new Controller();

			_viewDims = new Point(_view.X, _view.Y);
			_model = new Model {ScreenDimensions = _viewDims};
			_model.PlaceApple();

			var running = true;
			var paused = false;

			var newDirection = _model.Snake.CurrentDirection;
			_view.PaintEntities(_model.PrintBuffer);

			var timer = new Stopwatch();
			timer.Start();

			#region Game Loop

			// gameloop start

			while (running)
			{
				// Read keyPressed from View 
				var input = _view.GetInputKey();
				switch (input)
				{
					case Command.Quit:
					{
						running = false;
						continue;
					}
					case Command.Pause:
						paused = !paused;
						break;
					case Command.Up:
						newDirection = new Point(0, -1);
						break;
					case Command.Right:
						newDirection = new Point(1, 0);
						break;
					case Command.Down:
						newDirection = new Point(0, 1);
						break;
					case Command.Left:
						newDirection = new Point(-1, 0);
						break;
				}

				// if pause, the loop cycles back from here until unpaused
				if (paused || timer.ElapsedMilliseconds < 100) continue;
				timer.Restart();

				newDirection = _model.ValidateDirection(newDirection);

				Point newCoordinates = newDirection + _model.Snake.getHead().Coords;

				bool outOfBounds = _model.isOutOfBounds(newCoordinates);
				bool collidesSnake = _model.HitsSnake(newCoordinates);
				if (outOfBounds || collidesSnake)
				{
					running = false;
					continue;
				}


				if (newCoordinates == _model.Apple.Coords)
				{
					_model.SnakeEatsApple(newCoordinates);
					if (_model.Snake.Count - 1 == _viewDims.X*_viewDims.Y)
					{
						// Congrats, you win!
						running = false;
						continue;
					}
					_model.PlaceApple();
				}
				else
				{
					_model.SnakeMoves(newCoordinates);
				}


				// update
				_model.UpdatePrintableBuffer();

				// paint			
				_view.PaintEntities(_model.PrintBuffer);

				// clean out the " " printables
				_model.RefreshSnake();
			}
		}

		#endregion

		/*
		static void Initiate(InputListener listener)
		{
			_inputThread = new Thread(listener.Run);
			Subscribe(listener);
			_inputThread.Start();
		}


		private void Subscribe(InputListener listener)
		{
			listener.KeyPressed += OnKeyPressed;
		}


		public static void OnKeyPressed(object o, InputEventArgs input)
		{
			_inputKey = input.KeyPressed;
		}
		*/
	}
}