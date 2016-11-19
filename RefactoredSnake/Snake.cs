using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace RefactoredSnake
{
	public class Snake : List<GameEntity>
	{
		
		//public List<GameEntity> BodyL { get; private set; }
		private static readonly string _HEAD_CHAR = GameEntity.HeadChar;
		private static readonly string _BODY_CHAR = GameEntity.BodyChar;

		public GameEntity Head;
		public GameEntity Tail;

		public int BodyPartsCount => Count;


		public Snake(Point point, int length)
		{
			Add(new GameEntity(point, GameEntity.SnakeColor, _HEAD_CHAR));
			for (int i = 0; i < length-1; i++)
			{
				Insert(0, new GameEntity(point, GameEntity.SnakeColor, _BODY_CHAR));
			}
			Head = this.Last();
			Tail = this.First();
		}

		/// <summary>
		/// Construct the default snake with custom coordinates
		/// </summary>
		/// <param name="point"></param>
		public Snake(Point point): this(point, 4) { }

		/// <summary>
		/// The default constructor places the snake at the original
		/// solution's default spot
		/// </summary>
		public Snake() : this(new Point(10, 10)) { }

	
	}
}