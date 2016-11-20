using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

// WARNING: DO NOT code like this. Please. EVER! 
//          "Aaaargh!" 
//          "My eyes bleed!" 
//          "I facepalmed my facepalm." 
//          Etc.
//          I had a lot of fun obfuscating this code though! And I can now (proudly?) say that this is the uggliest short piece of code I've ever worked with! :-)
//          (And yes, it could have been a lot ugglier! But the idea wasn't to make it fuggly-uggly, just funny-uggly, sweet-uggly, or whatever you want to call it.)
//
//          -Tomas
//

namespace SnakeMess
{
	class SnakeMess
	{
		private static List<Point> _snake;
		private static Point _apple;

		private static Point _screenBoundaryPoint;

		static bool _running;
		static bool _pause;
		static bool _addOneMoreBodyPart;
		static Direction _newDirection;
		static Direction _lastDirection;

		static string _snakeBodyChar = "0";
		static string _snakeHeadChar = "@";
		static string _appleChar = "$";
		static Random _rand;
		static Stopwatch _time;


		public static void Main(string[] arguments)
		{
			#region Game Variables initialisation

/**
						 * INITIALISE GAME ELEMENTS
						 */

			// create game screen
			Console.CursorVisible = false;
			Console.Title = "Westerdals Oslo ACT - SNAKE";
			_screenBoundaryPoint = new Point(Console.WindowWidth, Console.WindowHeight);

			// initialise game state variables

			_running = true;
			_pause = false;

			_newDirection = Direction.Down;
			_lastDirection = _newDirection;

			// create, place and print snake 
			_addOneMoreBodyPart = false;
			_snake = new List<Point>
			{
				new Point(10, 10),
				new Point(10, 10),
				new Point(10, 10),
				new Point(10, 10)
			};
			PlaceCursor(_snake.Last());

			Console.Write(_snakeHeadChar);

			// Create _apple and place it

			_rand = new Random();
			_apple = new Point();
			do
			{
				_apple.X = _rand.Next(0, _screenBoundaryPoint.X);
				_apple.Y = _rand.Next(0, _screenBoundaryPoint.Y);
			} while (HitsSnake(_apple));

			Console.ForegroundColor = ConsoleColor.Green;
			Console.SetCursorPosition(_apple.X, _apple.Y);

			Console.Write(_appleChar);

			_time = new Stopwatch();
			_time.Start();

			#endregion

			#region Game Loop Starts

/**
						 * GAME LOOP START
						 */
			while (_running)
			{
				// check for user input
				if (Console.KeyAvailable)
				{
					// <-- this listens to input

					var inputKey = Console.ReadKey(true);

					if (inputKey.Key == ConsoleKey.Escape)
					{
						_running = false;
						continue;
					}

					if (inputKey.Key == ConsoleKey.Spacebar)
						_pause = !_pause;
					else if (inputKey.Key == ConsoleKey.UpArrow && _lastDirection != Direction.Down)
						_newDirection = Direction.Up;
					else if (inputKey.Key == ConsoleKey.RightArrow && _lastDirection != Direction.Left)
						_newDirection = Direction.Right;
					else if (inputKey.Key == ConsoleKey.DownArrow && _lastDirection != Direction.Up)
						_newDirection = Direction.Down;
					else if (inputKey.Key == ConsoleKey.LeftArrow && _lastDirection != Direction.Right)
						_newDirection = Direction.Left;
				}

				if (!_pause)
				{
					if (_time.ElapsedMilliseconds < 100)
					{
						continue;
					}
					_time.Restart();
					var snakeTail = _snake.First(); // new Point(_snake.First()));
					var snakeHead = _snake.Last(); // new Point(_snake.Last()));
					var newHead = new Point(snakeHead);

					switch (_newDirection)
					{
						case Direction.Up:
							newHead.Y -= 1;
							break;
						case Direction.Right:
							newHead.X += 1;
							break;
						case Direction.Down:
							newHead.Y += 1;
							break;
						default:
							newHead.X -= 1;
							break;
					}

					// The snake hits a wall
					if (HitWall(newHead)) _running = false;

					// This logic stack... 
					if (newHead == _apple) 
					{
						if (_snake.Count + 1 >= _screenBoundaryPoint.X*_screenBoundaryPoint.Y)
							// No more room to place apples - game over.
							_running = false;
						else {
							while (true){
								_apple.X = _rand.Next(0, _screenBoundaryPoint.X);
								_apple.Y = _rand.Next(0, _screenBoundaryPoint.Y);

								bool found = !HitsSnake(_apple); // y tho..

								if (found){
									_addOneMoreBodyPart = true;
									break;
								}
							}
						}
					}
					if (!_addOneMoreBodyPart) // No.
					{
						_snake.RemoveAt(0);
						foreach (var bodyPart in _snake)
							if (bodyPart == newHead)
							{
								// Death by accidental self-cannibalism.
								_running = false;
								break;
							} // Fuck this.
					}

					if (_running)
					{
						Console.ForegroundColor = ConsoleColor.Yellow;
						Console.SetCursorPosition(snakeHead.X, snakeHead.Y);
						Console.Write(_snakeBodyChar);

						if (_addOneMoreBodyPart)
						{
							Console.ForegroundColor = ConsoleColor.Green;
							Console.SetCursorPosition(_apple.X, _apple.Y);
							Console.Write(_appleChar);
							_addOneMoreBodyPart = false;
						}
						else
						{
							Console.SetCursorPosition(snakeTail.X, snakeTail.Y);
							Console.Write(" ");
						}
						_snake.Add(newHead);
						Console.ForegroundColor = ConsoleColor.Yellow;
						Console.SetCursorPosition(newHead.X, newHead.Y);
						Console.Write(_snakeHeadChar);
						_lastDirection = _newDirection;
					}
				}
			}

			#endregion
		}

		static void PlaceCursor(Point point)
		{
			Console.SetCursorPosition(point.X, point.Y);
		}

		public static bool HitsSnake(Point point)
		{
			bool isHit = false;

			foreach (var bodyPart in _snake)
			{
				if (bodyPart == point)
				{
					isHit = true;
					break;
				}
			}
			return isHit;
		}

		/// <summary>
		/// Check if a point is within the console window's bounds
		/// </summary>
		/// <param name="point"></param>
		/// <returns></returns>
		private static bool HitWall(Point point)
		{
			return point.X < 0 || point.X >= _screenBoundaryPoint.X || point.Y < 0 || point.Y >= _screenBoundaryPoint.Y;
		}
	}
}