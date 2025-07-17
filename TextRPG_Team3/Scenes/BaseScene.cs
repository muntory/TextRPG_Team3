using System;
using TextRPG_Team3.Utils;

public class BaseScene
{
    protected string msg;

    
    public virtual void Render()
	{
		Console.Clear();
	}


	public virtual void SelectMenu(int input)
	{

	}


    public void PrintMsg()
    {
        if (msg == null) return;
        
        RenderHelper.WriteLine(msg, ConsoleColor.DarkRed);
        RenderHelper.WriteLine();

        msg = null;
        
    }
}