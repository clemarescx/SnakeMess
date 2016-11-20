namespace RefactoredSnake
{
	/// <summary>
	/// All game commands are listed here
	/// 
	/// Could be expanded into an interface for Adapter DP?
	/// </summary>
	public enum Command
	{
		Quit, Pause, Up, Right, Down, Left, NoInput = -1
	}
}