using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactoredSnake {
	internal class Model {
		public List<PrintableEntity> PrintBuffer { get; }
		internal PrintableEntity Apple { get; set; }
		public Snake Snake { get; }
		private readonly Random _rand;
		public Point ScreenDimensions { private get; set; }

		public Model() {
			
			_rand = new Random();
			Apple = new PrintableEntity(new Point(30, 30), PrintableEntity.AppleColor,PrintableEntity.AppleChar);
			Snake = new Snake(new Point(10,10));
			PrintBuffer = new List<PrintableEntity>();

			UpdatePrintableBuffer();
		}

		public Point updateDirection(Point newDirection)
		{
			if (isValidNewDirection(newDirection))
			{
				return newDirection;
			}
			return Snake.CurrentDirection;
		}

		private bool isValidNewDirection(Point newDirection)
		{
			Point backwards = new Point(-newDirection.X, -newDirection.Y);

			return (newDirection != backwards) && 
				(newDirection != Snake.CurrentDirection);
		}

		public void SnakeMoves(Point newHeadPos)
		{
			Snake.Last().Character = PrintableEntity.BodyChar;
			Snake.AddHead(newHeadPos);
			Snake.First().Character = PrintableEntity.EmptyChar;
		}

		public void SnakeEatsApple(Point appleCoords) {
			Snake.Last().Character = PrintableEntity.BodyChar;
			Snake.AddHead(appleCoords);
		}

		public bool isOutOfBounds(Point point) {
			return point.X < 0 || 
				point.Y < 0 || 
				point.X >= ScreenDimensions.X || 
				point.Y >= ScreenDimensions.Y;
		}
		public void PlaceApple()
		{
			Point newAppleSpot = GetRandomPoint();
			while (CollidesWithSnake(newAppleSpot)){
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

		public bool CollidesWithSnake(Point point) {
			foreach (var bodyPart in Snake)
				if (bodyPart.Coords == point)
					return true;
			return false;
		}

		/// <summary>
		/// 
		/// </summary>
		public void UpdatePrintableBuffer() {
			PrintBuffer.Clear();
				
			PrintBuffer.AddRange(Snake);
			PrintBuffer.Add(Apple);
		}

		public void RefreshSnake()
		{
			while(Snake[0].Character.Equals(PrintableEntity.EmptyChar))
				Snake.RemoveAt(0);
		}

		public bool Contains(PrintableEntity entity) {
			return PrintBuffer.Contains(entity);
		}

		public bool Add(PrintableEntity entity) {
			if (PrintBuffer.Contains(entity))
				return false;
			PrintBuffer.Add(entity);
			return true;
		}

	}
}
