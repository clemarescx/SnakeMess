using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactoredSnake {

	class Model {
		public List<PrintableEntity> PrintBuffer { get; }
		internal PrintableEntity Apple { get; set; }
		public Snake Snake { get; }

		private Point screenDimensions;

		public Model() {
			Apple = new PrintableEntity(new Point(30, 30));
			Snake = new Snake();
			PrintBuffer = new List<PrintableEntity>();

			UpdatePrintableBuffer();
		}

		public void processCommand(ConsoleKey command) {

		}

		public void SnakeMoves(Point newHeadPos)
		{
			Snake.Last().Character = PrintableEntity.BodyChar;
			Snake.AddHead(newHeadPos);
			Snake.First().Character = PrintableEntity.EmptyChar;
		}

		public void SnakeEatsApple(Point appleCoords) {
			Snake.Last().Character = PrintableEntity.BodyChar;
			Snake.AddHead(appleCoords);
		}

		public void PlaceApple(Point newCoords)
		{
			Apple.Coords = newCoords;
		}

		public bool CollidesWithSnake(Point point) {
			foreach (var bodyPart in Snake)
				if (bodyPart.Coords == point)
					return true;
			return false;
		}

		/// <summary>
		/// 
		/// </summary>
		public void UpdatePrintableBuffer() {
			PrintBuffer.Clear();
				
			PrintBuffer.AddRange(Snake);
			PrintBuffer.Add(Apple);
		}

		public void RefreshSnake()
		{
			while(Snake[0].Character.Equals(PrintableEntity.EmptyChar))
				Snake.RemoveAt(0);
		}

		public bool Contains(PrintableEntity entity) {
			return PrintBuffer.Contains(entity);
		}

		public bool Add(PrintableEntity entity) {
			if (PrintBuffer.Contains(entity))
				return false;
			PrintBuffer.Add(entity);
			return true;
		}

	}
}
