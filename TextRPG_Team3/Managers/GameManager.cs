using System;

namespace TextRPG_Team3.Managers
{
	public class GameManager
	{
		private static GameManager instance;
		public static GameManager Instance { get { return instance; } }

		// 플레이어

		public GameManager()
		{
			if (instance == null)
			{
				instance = this;
			}
		}
	}
}