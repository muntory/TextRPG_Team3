using System;

public class BaseScene
{
	int menuMin;
	int menuMax;
	public int MenuMin
	{
		get { return menuMin; }
		set { menuMin = (value > 0) ? value : 0; }
	}

	public int MenuMax
	{
		get { return menuMax; }
		set { menuMax = (value > 0) ? value : 0; }
	}
	public virtual void Render()
	{
		Console.Clear();
	}
	public virtual void SelectMenu(int num)
	{

	}
}
