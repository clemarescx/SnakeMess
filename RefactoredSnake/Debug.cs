using System;

namespace RefactoredSnake
{
	public static class Debug
	{
		private static int lineCount = 0;
		public static void print(string str, params object[] args)
		{
			Console.SetCursorPosition(0,lineCount++);
			Console.WriteLine(str, args);

		}
		
	}
}