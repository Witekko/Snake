namespace Snake
{
    public class Meal
    {
        public Meal()
        {
            Random rand = new Random();
            var x = rand.Next(1, 69);
            var y = rand.Next(1, 29);
            CurrentTarget = new Coordinate(x, y);
            Draw();
        }

        public Coordinate CurrentTarget { get; set; }

        private void Draw()
        {
            Console.SetCursorPosition(CurrentTarget.X, CurrentTarget.Y);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("$");
        }
    }
}