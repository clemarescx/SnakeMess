using System;

namespace RefactoredSnake
{
	/// <summary>
	/// Represents a visible entity, including its coordinates
	/// and "textured model" (character + colour) 
	/// 
	/// Also contains the static reference for available characters
	/// and colours
	///  
	/// </summary>
	public class PrintableEntity
	{
		public static string HeadChar = "@";
		public static string BodyChar = "0";
		public static string AppleChar = "$";
		public static string EmptyChar = " ";

		public static ConsoleColor SnakeColor = ConsoleColor.Yellow;
		public static ConsoleColor AppleColor = ConsoleColor.Green;


		public Point Coords { get; set; }

		public ConsoleColor Color { get; set; }

		public string Character { get; set; }

		public PrintableEntity(
			Point point,
			ConsoleColor color = ConsoleColor.Magenta,
			string character = "X")
		{
			Coords = new Point(point);
			Color = color;
			Character = character;
		}

		public PrintableEntity(int x, int y) : this(new Point(x, y))
		{
		}

		public PrintableEntity(PrintableEntity entity) : this(entity.Coords, entity.Color, entity.Character)
		{
		}

		/// <summary>
		/// Default constructor
		/// </summary>
		public PrintableEntity() : this(0, 0)
		{
		}
	}
}