using System;

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
        
        Console.WriteLine(msg);
        Console.WriteLine();

        msg = null;
        
    }
}