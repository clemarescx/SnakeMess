using System;
using System.Runtime.CompilerServices;

namespace SnakeMess
{
	class Point
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

		public bool Equals(Point point)
		{			
			return X == point.X && Y == point.Y;
		}

		public static bool operator== (Point point1, Point point2)
		{
			return point1.Equals(point2);
		}

		public static bool operator !=(Point point1, Point point2)
		{
			return !(point1 == point2);
		}
	}
}