namespace RefactoredSnake
{
	/// <summary>
	/// 
	/// Not used, but would have been nice to implement,
	/// for instance by extracting a keyboard input class 
	/// from View and add a mock gamepad input listener
	/// class
	/// 
	/// </summary>
	public interface ICommand
	{
		Command Quit();
		Command Pause();
		Command GoUp();		
		Command GoRight();
		Command GoDown();
		Command GoLeft();
	}
}