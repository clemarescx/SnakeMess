namespace SnakeMess
{
	class Point
	{
		public const string Ok = "Ok";

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
	}
}