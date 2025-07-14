using TextRPG_Team3.Managers;

namespace TextRPG_Team3
{
    internal class Program
    {
        GameManager gameManager;
        SceneManager sceneManager;
        ResourceManager resourceManager;
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
            sceneManager = new SceneManager();
            resourceManager = new ResourceManager();
        }

        void Render()
        {

        }

        void Update()
        {

        }
    }
}
