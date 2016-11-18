using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace RefactoredSnake{
	class GameEntity {

		public int X { get; set; }
		public int Y { get; set; }

		public ConsoleColor Color;
		public string Character { get; set; }

		public GameEntity(int x = 0, int y = 0, ConsoleColor color = ConsoleColor.Magenta, string character = "X") {
			X = x;
			Y = y;
			Color = color;
			Character = character;
		}

		public GameEntity(GameEntity entity) : this(entity.X, entity.Y, entity.Color, entity.Character){}

		public void updateCoords(int newX, int newY)
		{
			X = newX;
			Y = newY;
		}

		public new bool Equals(Object obj) {
			if (!(obj is GameEntity))
				return false;
			GameEntity gameEntity = (GameEntity) obj;
			return X == gameEntity.X && Y == gameEntity.Y;
		}

		public static bool operator ==(GameEntity ent1, GameEntity ent2) {
			if (ent1.Equals(null))
				return false;
			return ent1.Equals(ent2);
		}

		public static bool operator !=(GameEntity ent1, GameEntity ent2) {
			return !(ent1 == ent2);
		}
	}
}