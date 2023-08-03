namespace Snake
{
    internal class Game
    {
        private Snake snake;
        private Meal meal;
        private bool exit;
        private double frameRate = 1000 / 5.0;
        private DateTime lastDate = DateTime.Now;

        public void Start()
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(69, 30);
            Console.SetBufferSize(70, 30);

            exit = false;

            Console.SetCursorPosition(20, 15);
            Console.WriteLine(" Press any key to start the game!!!");
            Console.ReadKey();
            Console.Clear();
            snake = new Snake();
            meal = new Meal();
        }

        public void GameLoop()
        {
            while (!exit)
            {
                HandleInput();
                UpdateGame();
            }
        }

        private void HandleInput()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo input = Console.ReadKey(true); // Parametr 'true' powoduje, że klawisz nie jest wyświetlany na ekranie.

                switch (input.Key)
                {
                    case ConsoleKey.Escape:
                        exit = true;
                        break;

                    case ConsoleKey.LeftArrow:
                        snake.Direction = Direction.Left;
                        break;

                    case ConsoleKey.RightArrow:
                        snake.Direction = Direction.Right;
                        break;

                    case ConsoleKey.UpArrow:
                        snake.Direction = Direction.Up;
                        break;

                    case ConsoleKey.DownArrow:
                        snake.Direction = Direction.Down;
                        break;
                }
            }
        }

        private void UpdateGame()
        {
            if ((DateTime.Now - lastDate).TotalMilliseconds >= frameRate)
            {
                snake.Move();

                if (snake.HeadPosition.X == meal.CurrentTarget.X && snake.HeadPosition.Y == meal.CurrentTarget.Y)
                {
                    snake.EatMeal();
                    meal = new Meal();
                    frameRate /= 1.05;
                }

                if (snake.GameOver)
                {
                    exit = true;
                    Console.Clear();
                    Console.WriteLine($"GAME OVER!! YOUR SCORE: {snake.Lenght}");
                    Console.Read();
                }
                lastDate = DateTime.Now;
            }
        }
    }
}