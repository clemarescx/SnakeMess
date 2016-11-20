using System;
using System.Diagnostics;

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

		public void MoveTo(int newX, int newY)
		{
			X = newX;
			Y = newY;
		}

		public void MoveTo(Point point)
		{
			MoveTo(point.X, point.Y);
		}

		public new bool Equals(Object obj)
		{
			if (!(obj is Point))
				return false;
			Point point = (Point) obj;
			return X == point.X && Y == point.Y;
		}

		public static bool operator ==(Point point1, Point point2)
		{
			if (point1.Equals(null))
				return false;
			return point1.Equals(point2);
		}

		public static bool operator !=(Point point1, Point point2)
		{
			return !(point1 == point2);
		}
	}
}