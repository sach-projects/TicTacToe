namespace TicTacToe;

internal abstract class Program
{
    private static void Main()
    {
        var playAgain = true;
        var game = new Game();
        game.Start();
        while (playAgain)
        {
            var result = game.Play();
            Console.WriteLine(result.ToLower().Equals("unknown")
                ? "An error occured and we couldn't give results of this game."
                : result);
            Console.WriteLine("Fancy another game? (y/n)");
            playAgain = Console.ReadLine() == "y";
            if (playAgain)
            {
                game.Stop();
            }
        }
        Console.WriteLine("Have a great day!");
    }
}
