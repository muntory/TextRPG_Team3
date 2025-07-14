namespace TextRPG_Team3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*Program program = new();
            program.Init();

            while (true)
            {
                program.Render();
                program.Update();
            }*/
            int a = 3;
            int b = 5;
            int answer = 0;

            for(int i = 0; i <= a; i++)
            {
                answer += b;
            }

            Console.Write(answer);
        }

        void Init()
        {

        }

        void Render()
        {

        }

        void Update()
        {

        }
    }
}
