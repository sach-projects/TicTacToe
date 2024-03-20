using System.Data;

namespace TicTacToe;

public class Game
{
    private readonly Board _board = new();
    private Player PlayerOne { get; set; } = null!;
    private Player PlayerTwo { get; set; } = null!;

    public void Start()
    {
        var playerOneName = GetPlayerDetails();
        var playerTwoName = GetPlayerDetails();
        PlayerOne = new Player(playerOneName, Player.PlayerCharacter.X);
        PlayerTwo = new Player(playerTwoName, Player.PlayerCharacter.O);
    }

    private string GetPlayerDetails()
    {
        Console.WriteLine("Please Enter Player name:");
        var playerName = Console.ReadLine();
        var counter = 0;
        const int limit = 5;
        while(string.IsNullOrEmpty(playerName) && counter <= limit)
        {
            Console.WriteLine("Player name should not be empty, please enter a valid name:");
            playerName = Console.ReadLine();
            counter++;
        }
        if (string.IsNullOrEmpty(playerName))
        {
            throw new ConstraintException("Entered invalid name too many times");
        }

        return playerName;
    }

    public string Play()
    {
        _board.DisplayBoard();
        for (var move = 0; move < 9; move ++)
        {
            MakeAMove(move % 2 == 0 ? PlayerOne : PlayerTwo);
            _board.DisplayBoard();
            if (move < 4) continue;
            var gameStatus = CheckForWin();
            if (!gameStatus.ToLower().Equals("incomplete"))
            {
                return gameStatus;
            }
        }

        return "unknown";
    }

    private void MakeAMove(Player player)
    {
        Console.WriteLine($"{player.Name}, please select an available position:");
        var position = Console.ReadLine();
        while(string.IsNullOrEmpty(position) || !_board.IsPositionAvailable(position))
        {
            Console.WriteLine("Invalid position!!! \n Please enter a valid, non-empty and available position:");
            position = Console.ReadLine();
        }
        
        _board.UpdateBoard(position,player.Character);
    }

    private string CheckForWin()
    {
        if (_board.IsWinner(PlayerOne.Character))
        {
            return $"{PlayerOne.Name} wins";
        }
        
        if (_board.IsWinner(PlayerTwo.Character))
        {
            return $"{PlayerTwo.Name} wins";
        } 
        
        return _board.IsDraw() ? "It's a draw" : "incomplete";
    }
    
    public void Stop()
    {
        _board.ResetBoard();
    }
}