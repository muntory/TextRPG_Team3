using System;

public class SceneManager
{
	private static private SceneManager instance = new();
	public static SceneManager Instance => instance ?? (_instance = new());

	public SceneManager()
	{

	}

}
