using System;

namespace RefactoredSnake
{
	/// <summary>
	/// Helper class to print debugging text
	/// </summary>
	public static class Debug
	{
		private static int _lineCount = 0;
		public static void Print(string str, params object[] args)
		{
			Console.ForegroundColor = ConsoleColor.Magenta;
			Console.SetCursorPosition(0,_lineCount++);
			Console.WriteLine(str, args);
		}
		
	}
}