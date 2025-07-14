using System;

public class GameManager 
{
	private static GameManager instance;
	public static GameManager Instance { get { return instance; } }
	public GameManager()
	{
		if (instance == null)
		{
			instance = this;
		}
	}
}
