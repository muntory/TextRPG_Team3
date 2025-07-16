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
        InputManager inputManager;
        SpawnManager spawnManager;
        QuestManager questManager;

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
            spawnManager = new SpawnManager();
            resourceManager = new ResourceManager();
            sceneManager = new SceneManager();
            inputManager = new InputManager();
            questManager = new QuestManager();
            SceneManager.Instance.LoadScene(new ChooseScene());
        }

        void Render()
        {
            SceneManager.Instance.CurrentScene.Render();
        }

        void Update()
        {
            int selectedNumber = InputManager.Instance.GetPlayerInput();

            SceneManager.Instance.CurrentScene.SelectMenu(selectedNumber);
        }
    }
}
