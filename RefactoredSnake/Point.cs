namespace RefactoredSnake
{
	/// <summary>
	/// Contains a set of 2D coordinates
	/// </summary>
	public class Point
	{
		public int X;
		public int Y;

		public Point(int x = 0, int y = 0)
		{
			X = x;
			Y = y;
		}

		public Point(Point input)
		{
			X = input.X;
			Y = input.Y;
		}


		public static bool operator ==(Point point1, Point point2)
		{
			return point1.Equals(point2);
		}

		public static bool operator !=(Point point1, Point point2)
		{
			return !(point1 == point2);
		}

		public static Point operator +(Point point1, Point point2)
		{
			return new Point(point1.X + point2.X, point1.Y + point2.Y);
		}

		public override string ToString()
		{
			string pointStr = "(" + X + ", " + Y + ")";
			return pointStr;
		}

		/**
		 * Generated Equals, GetHashCode
		 */

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj))
				return false;
			if (ReferenceEquals(this, obj))
				return true;
			if (obj.GetType() != GetType())
				return false;
			Point other = (Point) obj;
			return X == other.X && Y == other.Y;
		}

		public override int GetHashCode()
		{
			unchecked
			{
				return (X*397) ^ Y;
			}
		}
	}
}