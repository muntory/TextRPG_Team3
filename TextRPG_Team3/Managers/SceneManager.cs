using System;
using TextRPG_Team3.Scenes;

namespace TextRPG_Team3.Managers
{
	public class SceneManager
	{
		private static SceneManager instance;
		public static SceneManager Instance {  get { return instance; } }

    public BaseScene CurrentScene { get; set; }

    public SceneManager()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
}
