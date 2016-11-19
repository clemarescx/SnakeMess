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

			var newDirection = new Point(0,1);
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
				

				if (paused || timer.ElapsedMilliseconds < 100) continue;
				timer.Restart();
				 //Console.WriteLine("newDirection{0}", newDirection);

				_model.updateDirection(newDirection);
				/*
				int newCoordsX = newDirection.X + _model.Snake.Head.Coords.X;
				int newCoordsY = newDirection.Y + _model.Snake.Head.Coords.Y;
				*/
				int newCoordsX = newDirection.X + _model.Snake.getHead().Coords.X;
				int newCoordsY = newDirection.Y + _model.Snake.getHead().Coords.Y;
				Point newCoordinates = new Point(newCoordsX, newCoordsY);


				//Console.WriteLine("newCoordinates == {0}, press a key", newCoordinates);
				//Console.ReadKey(true);

				if (_model.isOutOfBounds(newCoordinates) || _model.CollidesWithSnake(newCoordinates))
				{
					running = false;
					//Console.WriteLine("out of bounds || collides with snake, press a key");
					//Console.ReadKey(true);
					continue;
				}

				if ( newCoordinates == _model.Apple.Coords)
				{
					//Console.WriteLine(" new direction {0} == applecoords {1}",newCoordinates, _model.Apple.Coords);
					//Console.ReadKey(true);

					_model.SnakeEatsApple(newCoordinates);
					if (_model.Snake.Count - 1 == _viewDims.X*_viewDims.Y)
					{
						running = false;
						continue;
					}
					_model.PlaceApple();
				}

				_model.SnakeMoves(newCoordinates);

				// update
				_model.UpdatePrintableBuffer();

				//paint			
				_view.PaintEntities(_model.PrintBuffer);

				//
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