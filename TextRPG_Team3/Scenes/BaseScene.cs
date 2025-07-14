using System;
using TextRPG_Team3.Interfaces;

public class BaseScene : IScene
{
	public virtual void Render(ref int menuMin, ref int menuMax)
	{
		Console.Clear();
	}
	public virtual void SelectMenu(int num)
	{

	}
}

