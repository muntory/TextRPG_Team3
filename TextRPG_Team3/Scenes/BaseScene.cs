using System;
using TextRPG_Team3.Interfaces;

public class BaseScene : IScene
{
	public virtual void Render()
	{
		Console.Clear();
	}
}
