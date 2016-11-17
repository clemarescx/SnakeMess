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
namespace SnakeMess {
	class SnakeMess {

		private static List<Point> _snake;
		private static Point _screenBoundaryPoint;

		enum Direction {
			Up, Right, Down, Left
		}

		public static void Main(string[] arguments) {
			/**
			 * INITIALISE GAME ELEMENTS
			 */
			//bool gg = false;
			bool running = true;
			bool pause = false;
			bool addOneMoreBodyPart = false;

			// short newDir = 2;
			// short last = newDir;
			Direction newDirection = Direction.Down; // 0 = up, 1 = right, 2 = down, 3 = left
			Direction lastDirection = newDirection;

			//Random rng = new Random();
			//Point app = new Point();
			_screenBoundaryPoint = new Point(Console.WindowWidth, Console.WindowHeight);
			_snake = new List<Point>();
			var rand = new Random();
			var apple = new Point();

			//var snake = new List<Point>();
			_snake.Add(new Point(10, 10));
			_snake.Add(new Point(10, 10));
			_snake.Add(new Point(10, 10));
			_snake.Add(new Point(10, 10));

			//int boardW = Console.WindowWidth, boardH = Console.WindowHeight;

			Console.CursorVisible = false;
			Console.Title = "Westerdals Oslo ACT - SNAKE";
			Console.SetCursorPosition(10, 10);
			Console.Write("@");

			while (true) {
				//apple.X = rand.Next(0, boardW);
				//apple.Y = rand.Next(0, boardH);
				apple.X = rand.Next(0, _screenBoundaryPoint.X);
				apple.Y = rand.Next(0, _screenBoundaryPoint.Y);
				bool spot = !HeadHits(apple);
				/*
				  bool spot = true;
				  foreach (var bodyPart in _snake){
					if (bodyPart == apple) {
						spot = false;
						break;
					}
				}
				*/
				if (spot) {
					Console.ForegroundColor = ConsoleColor.Green;
					Console.SetCursorPosition(apple.X, apple.Y);
					Console.Write("$");
					break;
				}
			}

			var time = new Stopwatch();
			time.Start();

			/**
			 * GAME LOOP START
			 */

			while (running) {
				if (Console.KeyAvailable) {
					var inputKey = Console.ReadKey(true);
					if (inputKey.Key == ConsoleKey.Escape)
						running = false;
					else if (inputKey.Key == ConsoleKey.Spacebar)
						pause = !pause;
					else if (inputKey.Key == ConsoleKey.UpArrow && lastDirection != Direction.Down)
						newDirection = Direction.Up;
					else if (inputKey.Key == ConsoleKey.RightArrow && lastDirection != Direction.Left)
						newDirection = Direction.Right;
					else if (inputKey.Key == ConsoleKey.DownArrow && lastDirection != Direction.Up)
						newDirection = Direction.Down;
					else if (inputKey.Key == ConsoleKey.LeftArrow && lastDirection != Direction.Right)
						newDirection = Direction.Left;
				}

				if (!pause) {
					if (time.ElapsedMilliseconds < 100) {
						continue;
					}
					time.Restart();
					var tail = new Point(_snake.First());
					var head = new Point(_snake.Last());
					var newH = new Point(head);
					switch (newDirection) {
						case Direction.Up:
							newH.Y -= 1;
							break;
						case Direction.Right:
							newH.X += 1;
							break;
						case Direction.Down:
							newH.Y += 1;
							break;
						default:
							newH.X -= 1;
							break;
					}

					//if (newH.X < 0 || newH.X >= boardW || newH.Y < 0 || newH.Y >= boardH)
					//if (newH.X < 0 || newH.X >= _screenBoundaryPoint.X || newH.Y < 0 || newH.Y >= _screenBoundaryPoint.Y)
					if (OutOfBoard(newH))
					{
						running = false;
					}


					if (newH == apple) {
//						if (Snake.Count + 1 >= boardW * boardH)
						if (_snake.Count + 1 >= _screenBoundaryPoint.X * _screenBoundaryPoint.Y)
							// No more room to place apples - game over.
							running = false;
						else {
							while (true) {
								apple.X = rand.Next(0, _screenBoundaryPoint.X);
								apple.Y = rand.Next(0, _screenBoundaryPoint.Y);

								bool found = !HeadHits(apple);

								if (found) {
									addOneMoreBodyPart = true;
									break;
								}
							}
						}
					}

					if (!addOneMoreBodyPart) {
						_snake.RemoveAt(0);
						
						foreach (var bodyPart in _snake)
							if (bodyPart == newH) {
								// Death by accidental self-cannibalism.
								running = false;
								break;
							}

					}

					if (running) {
						Console.ForegroundColor = ConsoleColor.Yellow;
						Console.SetCursorPosition(head.X, head.Y);
						Console.Write("0");

						if (!addOneMoreBodyPart) {
							Console.SetCursorPosition(tail.X, tail.Y);
							Console.Write(" ");
						}
						else {
							Console.ForegroundColor = ConsoleColor.Green;
							Console.SetCursorPosition(apple.X, apple.Y);
							Console.Write("$");
							addOneMoreBodyPart = false;
						}
						_snake.Add(newH);
						Console.ForegroundColor = ConsoleColor.Yellow;
						Console.SetCursorPosition(newH.X, newH.Y);
						Console.Write("@");
						lastDirection = newDirection;
					}
				}
			}
		}

		private static bool HeadHits(Point point) {
			bool collidesWithSnake = false;

			foreach (var bodyPart in _snake) {
				if (bodyPart == point) {
					collidesWithSnake = true;
					break;
				}
			}
			return collidesWithSnake;
		}

		private static bool OutOfBoard(Point point)
		{
			return point.X < 0 || point.X >= _screenBoundaryPoint.X || point.Y < 0 || point.Y >= _screenBoundaryPoint.Y;
		}
	}
}