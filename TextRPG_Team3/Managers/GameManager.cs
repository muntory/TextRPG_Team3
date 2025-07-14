using System;

public class GameManager
{
	private static GameManager instance;
	public static GameManager Instance => instance ?? (instance = new());
	public GameManager()
	{
	}
}
