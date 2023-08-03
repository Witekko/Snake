namespace Snake;

internal class Program
{
    private static void Main()
    {
        Console.CursorVisible = false;

        Game game = new Game();
        game.Start();
        game.GameLoop();
    }
}