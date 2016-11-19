using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactoredSnake {

	class Model
	{
		public List<GameEntity> PrintBuffer { get; }
		internal GameEntity Apple { get; set; }
		public Snake Snake { get; }

		public Model()
		{
			Apple = new GameEntity(new Point(30,30));
			Snake = new Snake();
			PrintBuffer = new List<GameEntity>();

			UpdateEntities();

		}

		public void processCommand(ConsoleKey command)
		{
			
		}

		public void UpdateEntities()
		{
			PrintBuffer.RemoveRange(0,PrintBuffer.Count);
			PrintBuffer.AddRange(Snake.Body);
			PrintBuffer.Add(Apple);
		}

		public bool contains(GameEntity entity)
		{
			return PrintBuffer.Contains(entity);
		}

		public bool add(GameEntity entity)
		{
			if (PrintBuffer.Contains(entity)) return false;
			PrintBuffer.Add(entity);
			return true;
		}



		public Point Move(Point newHeadPos) {
			Enqueue(newHeadPos);
			GameEntity oldTail = Dequeue();

			return oldTail.Coords;
		}
		
		public void Enqueue(Point newHeadPos) {
			if (Head != null)
				Head.Character = GameEntity.BodyChar;

			Body.Add(new GameEntity(newHeadPos, ConsoleColor.Yellow, GameEntity.HeadChar));
		}

		private GameEntity Dequeue() {
			var tail = Tail;
			Body.RemoveAt(0);
			tail.Character = " ";
			return tail;
		}

	}
}
