using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace RefactoredSnake{
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
			string character = "X") {
			Coords = new Point(point);
			Color = color;
			Character = character;
		}
		public PrintableEntity(int x, int y) : this(new Point(x, y)){}

		public PrintableEntity(PrintableEntity entity) : this(entity.Coords, entity.Color, entity.Character){}

		public void UpdateCoords(Point point)
		{
			Coords = new Point(point);
		}


		/*
		public new bool Equals(Object obj) {
			if (!(obj is PrintableEntity))
				return false;
			PrintableEntity gameEntity = (PrintableEntity) obj;
			//return X == gameEntity.X && Y == gameEntity.Y;
			return this.Coords == gameEntity.Coords;
		}

		public static bool operator ==(PrintableEntity ent1, PrintableEntity ent2)
		{
			return ent1 != null && ent1.Equals(ent2);
		}

		public static bool operator !=(PrintableEntity ent1, PrintableEntity ent2) {
			return !(ent1 == ent2);
		}
		*/
	}
}