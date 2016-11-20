using System.Diagnostics;

namespace RefactoredSnake
{
	/// <summary>
	/// Following the MVC patter to the letter, this is the binding
	/// class between I/O (view) and "database"/element behaviour
	/// 
	/// It contains the main method, which contains the game loop
	/// </summary>
	internal class Controller
	{
		private static Point _viewDims;
		private static View _view;
		private static Model _model;

		public Controller()
		{
			_view = new View();
			_viewDims = new Point(_view.X, _view.Y);
			_model = new Model { ScreenDimensions = _viewDims };
		}

		public Direction Direction {
			get {
				throw new System.NotImplementedException();
			}

			set {
			}
		}

		public static void Main(string[] args)
		{
			new Controller();

			var running = true;
			var paused = false;
			_model.PlaceApple();
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

				newDirection = _model.ValidateDirection(newDirection); // dismisses backwards
				Point newCoordinates = newDirection + _model.Snake.GetHead().Coords;

				// check new coordinates for lose conditions
				bool outOfBounds = _model.IsOutOfBounds(newCoordinates);
				bool collidesSnake = _model.HitsSnake(newCoordinates);
				if (outOfBounds || collidesSnake)
				{
					running = false;
					continue;
				}

				// what happens when the snake's head meets the apple
				if (newCoordinates == _model.Apple.Coords)
				{
					_model.SnakeEatsApple(newCoordinates);
					if (_model.Snake.Count == _viewDims.X * _viewDims.Y)
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

				// update the state of the game and the view
				_model.UpdatePrintableBuffer();
				_view.PaintEntities(_model.PrintBuffer);
				_model.RefreshSnake();
			}
		}

		#endregion

		/*
		 * Below are the boilerplate subscriber methods 
		 * for the delegate-event based Observer 
		 * (publisher-suscriber) design pattern.
		 * 
		 * But delegate + events + threading proved
		 * too difficult to debug / handle...
		 * 
		 * 
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