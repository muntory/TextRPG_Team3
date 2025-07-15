using TextRPG_Team3.Scenes;
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
            SceneManager.Instance.CurrentScene.Render();
        }

        void Update()
        {
            int selectedNumber = InputManager.Instance.GetMenuNumber();

            SceneManager.Instance.CurrentScene.SelectMenu(selectedNumber);
        }
    }
}
