namespace Snake
{
    internal class Snake : ISnake
    {
        public int Lenght { get; set; } = 5;
        public Direction Direction { get; set; } = Direction.Right;
        public Coordinate HeadPosition { get; set; } = new Coordinate(0, 0);
        private List<Coordinate> Tail { get; set; } = new List<Coordinate>();
        private bool outOfRange;

        public bool GameOver
        {
            get { return Tail.Where(c => c.X == HeadPosition.X && c.Y == HeadPosition.Y).ToList().Count > 1 || outOfRange; }
        }

        public void EatMeal()
        {
            Lenght++;
        }

        public void Move()
        {
            switch (Direction)
            {
                case Direction.Left:
                    HeadPosition.X--;
                    break;

                case Direction.Right:
                    HeadPosition.X++;
                    break;

                case Direction.Up:
                    HeadPosition.Y--;

                    break;

                case Direction.Down:
                    HeadPosition.Y++;
                    break;
            }
            if (HeadPosition.X < Console.BufferWidth && HeadPosition.Y < Console.BufferHeight && HeadPosition.X >= 0 && HeadPosition.Y >= 0)
            {
                Console.SetCursorPosition(HeadPosition.X, HeadPosition.Y);
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write("@");
                Tail.Add(new Coordinate(HeadPosition.X, HeadPosition.Y));
                if (Tail.Count > this.Lenght)
                {
                    var endTail = Tail.First();
                    Console.SetCursorPosition(endTail.X, endTail.Y);
                    Console.Write(" ");
                    Tail.Remove(endTail);
                }
            }
            else
            {
                outOfRange = true;
            }
        }
    }

    public enum Direction
    { Left, Right, Up, Down }
}