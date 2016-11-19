using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace RefactoredSnake{
	public class GameEntity
	{

		public static string HeadChar = "@";
		public static string BodyChar = "0";
		public static string AppleChar = "$";
		public static ConsoleColor SnakeColor = ConsoleColor.Yellow;
		public static ConsoleColor AppleColor = ConsoleColor.Green;


		public Point Coords { get; set; }

		public ConsoleColor Color { get; set; }

		public string Character { get; set; }

		public GameEntity(
			Point point, 
			ConsoleColor color = ConsoleColor.Magenta, 
			string character = "X") {
			Coords = new Point(point);
			Color = color;
			Character = character;
		}
		public GameEntity(int x, int y) : this(new Point(x, y)){}

		public GameEntity(GameEntity entity) : this(entity.Coords, entity.Color, entity.Character){}

		public void UpdateCoords(Point point)
		{
			Coords = new Point(point);
		}


		/*
		public new bool Equals(Object obj) {
			if (!(obj is GameEntity))
				return false;
			GameEntity gameEntity = (GameEntity) obj;
			//return X == gameEntity.X && Y == gameEntity.Y;
			return this.Coords == gameEntity.Coords;
		}

		public static bool operator ==(GameEntity ent1, GameEntity ent2)
		{
			return ent1 != null && ent1.Equals(ent2);
		}

		public static bool operator !=(GameEntity ent1, GameEntity ent2) {
			return !(ent1 == ent2);
		}
		*/
	}
}