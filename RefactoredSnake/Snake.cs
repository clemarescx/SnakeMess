using System;
using System.Collections.Generic;
using System.Linq;

namespace RefactoredSnake
{
	public class Snake
	{
		public List<GameEntity> Body { get; private set; }

		public GameEntity Head;
		public GameEntity Tail;

		public int BodyPartsCount => Body.Count;


		public Snake(Point point, int length)
		{
			Body = new List<GameEntity>();
			for (int i = 0; i < length; i++)
			{
				Enqueue(point);
			}
			Head = Body.Last();
			Tail = Body.First();


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



		public Point Move(Point newHeadPos)
		{
			Enqueue(newHeadPos);
			GameEntity oldTail = Dequeue();

			return oldTail.Coords;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="newHeadPos"></param>

		public void Enqueue(Point newHeadPos)
		{
			if( Head != null ) Head.Character = GameEntity._BODY_CHAR;

			Body.Add(new GameEntity(newHeadPos, ConsoleColor.Yellow, GameEntity._HEAD_CHAR));
		}

		private GameEntity Dequeue()
		{
			var tail = Tail;
			Body.RemoveAt(0);
			tail.Character = " ";
			return tail;
		}

	}
}