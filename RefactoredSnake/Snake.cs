using System.Collections.Generic;
using System.Linq;

namespace RefactoredSnake
{
	/// <summary>
	/// The snake class represents how the snake is built
	/// (i.e. where the tail and the head are) and which direction
	/// it's headed for.
	/// </summary>
	public class Snake : List<PrintableEntity>
	{
		private static readonly string HeadChar = PrintableEntity.HeadChar;
		private static readonly string BodyChar = PrintableEntity.BodyChar;

		public Point CurrentDirection;

		public Snake(Point startingCoords, Point direction, int length)
		{
			// Construct the body first
			for (int i = 0; i < length - 1; i++)
			{
				Insert(0, new PrintableEntity(startingCoords, PrintableEntity.SnakeColor, BodyChar));
			}
			// Then add the head
			AddHead(startingCoords);
			CurrentDirection = direction;
		}
		
		public Snake(Point startingCoords) : this(startingCoords, new Point(0, 1), 4)
		{
		}

		/// <summary>
		/// The default constructor places the snake at the original
		/// solution's default spot
		/// </summary>
		public Snake() : this(new Point(10, 10))
		{
		}

		public void AddHead(Point point)
		{
			Add(new PrintableEntity(point, PrintableEntity.SnakeColor, HeadChar));
		}

		public PrintableEntity GetHead()
		{
			return this.Last();
		}

		public PrintableEntity GetTail()
		{
			return this.First();
		}
	}
}