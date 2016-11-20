using System;
using System.Collections.Generic;
using System.Linq;

namespace RefactoredSnake {
	internal class Model
	{
		public List<PrintableEntity> PrintBuffer { get; }
		internal PrintableEntity Apple { get; set; }
		public Snake Snake { get; }
		private readonly Random _rand;
		public Point ScreenDimensions { private get; set; }


		public Model()
		{
			_rand = new Random();
			Apple = new PrintableEntity(new Point(30, 30), PrintableEntity.AppleColor, PrintableEntity.AppleChar);
			Snake = new Snake(new Point(10, 10));
			PrintBuffer = new List<PrintableEntity>();

			UpdatePrintableBuffer();
		}

		/// <summary>
		/// Returns and update the snake's direction only if
		/// the snake doesn't attempt to eat its own face
		/// (i.e. the direction is towards the snake's body)
		/// </summary>
		/// <param name="newDirection"></param>
		/// <returns></returns>
		public Point ValidateDirection(Point newDirection)
		{
			var nullVector = new Point();	// vector (0,0)
			if ((Snake.CurrentDirection + newDirection) != nullVector)
			{
				Snake.CurrentDirection = newDirection;
			}
			return Snake.CurrentDirection;
		}


		public void SnakeMoves(Point newHeadPos)
		{
			Snake.Last().Character = PrintableEntity.BodyChar;
			Snake.AddHead(newHeadPos);
			Snake.First().Character = PrintableEntity.EmptyChar;
		}

		public void SnakeEatsApple(Point appleCoords)
		{
			Snake.Last().Character = PrintableEntity.BodyChar;
			Snake.AddHead(appleCoords);
		}

		public bool IsOutOfBounds(Point point)
		{
			return point.X < 0 ||
			       point.Y < 0 ||
			       point.X >= ScreenDimensions.X ||
			       point.Y >= ScreenDimensions.Y;
		}

		public void PlaceApple()
		{
			Point newAppleSpot = GetRandomPoint();
			while (HitsSnake(newAppleSpot))
			{
				newAppleSpot = GetRandomPoint();
			}
			Apple.Coords = newAppleSpot;
		}

		public Point GetRandomPoint()
		{
			int randX = _rand.Next(0, ScreenDimensions.X);
			int randY = _rand.Next(0, ScreenDimensions.Y);

			return new Point(randX, randY);
		}

		public bool HitsSnake(Point point)
		{
			foreach (var bodyPart in Snake)
				if (bodyPart.Coords == point)
					return true;
			return false;
		}

		/// <summary>
		/// 
		/// </summary>
		public void UpdatePrintableBuffer()
		{
			PrintBuffer.Clear();

			PrintBuffer.AddRange(Snake);
			PrintBuffer.Add(Apple);
		}

		/// <summary>
		/// Once elements are printed, "empty" printables
		/// are cleaned out from the buffer
		/// </summary>
		public void RefreshSnake()
		{
			while (Snake[0].Character.Equals(PrintableEntity.EmptyChar))
				Snake.RemoveAt(0);
		}
	}
}