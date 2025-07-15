using TextRPG_Team3.Others;
using TextRPG_Team3.Scenes;
using TextRPG_Team3.Interfaces;
using TextRPG_Team3.Character;
using TextRPG_Team3.Managers;

namespace TextRPG_Team3
{
    internal class Program
    {
        GameManager gameManager;
        ResourceManager resourceManager;
        SceneManager sceneManager;
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
            gameManager = new GameManager();
            gameManager.Player = new PlayerCharacter();
            resourceManager = new ResourceManager();
            sceneManager = new SceneManager();
            SceneManager.Instance.CurrentScene = new IntroScene();

        }

        void Render()
        {
            Console.Clear();
            SceneManager.Instance.CurrentScene.Render();
        }

        void Update()
        {
            GetNumber numberGetter = new();

            int menuMin = SceneManager.Instance.CurrentScene.MenuMin;
            int menuMax = SceneManager.Instance.CurrentScene.MenuMax;
            int selectedNumber = numberGetter.GetMenuNumber(menuMin, menuMax);

            SceneManager.Instance.CurrentScene.SelectMenu(selectedNumber);
        }
    }
}
