using TextRPG_Team3.Others;
using TextRPG_Team3.Scenes;
using TextRPG_Team3.Interfaces;

namespace TextRPG_Team3
{
    internal class Program
    {
        SceneManager sceneManager;
        int menuMin = 0;
        int menuMax = 0;
        static void Main(string[] args)
        {
            Program program = new();
            program.Init();

            while (true)
            {
                program.Render();
                program.Update();
            }
        }

        void Init()
        {
            sceneManager = new SceneManager();
            SceneManager.Instance.CurrentScene = new IntroScene();
        }

        void Render()
        {
            Console.Clear();
            SceneManager.Instance.CurrentScene.Render(ref menuMin, ref menuMax);
        }

        void Update()
        {
            GetNumber numberGetter = new();
            int selectedNumber = numberGetter.GetMenuNumber(menuMin, menuMax);
            SceneManager.Instance.CurrentScene.SelectMenu(selectedNumber);
        }
    }
}
