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

		public Model()
		{
			Entities = new List<GameEntity>();
		}

		public void updateEntities()
		{
			
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
