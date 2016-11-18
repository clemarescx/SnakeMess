using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactoredSnake {

	class Model
	{
		public List<GameEntity> Entities { get; }

		internal GameEntity Apple { get; set; }

		public Snake Snake { get; }

		public Model()
		{
			Apple = new GameEntity(new Point(30,30));
			Snake = new Snake();
			Entities = new List<GameEntity>();

			UpdateEntities();

		}

		// View board = new View();
		// _board.paintEntities(entities);


		public void UpdateEntities()
		{
			Entities.RemoveRange(0,Entities.Count);
			Entities.AddRange(Snake.Body);
			Entities.Add(Apple);
		}

		public bool contains(GameEntity entity)
		{
			return Entities.Contains(entity);
		}

		public bool add(GameEntity entity)
		{
			if (Entities.Contains(entity)) return false;
			Entities.Add(entity);
			return true;
		}
	}
}
