namespace TicTacToe;

public class Board
{
    private string[,] _board = null!;
    private Dictionary<string, (int, int)> _positionDictionary = null!;

    public Board()
    {
        Initialize();
    }

    private void Initialize()
    {
        _positionDictionary = new Dictionary<string, (int, int)>();
        _board = new[,] { { "1", "2", "3" }, { "4", "5", "6" }, { "7", "8", "9" } };
        PopulateDictionary();
    }

    private void PopulateDictionary()
    {
        var counter = 1;
        for (var i = 0; i < 3; i++)
        {
            for (var j = 0; j < 3; j++)
            {
                _positionDictionary.Add($"{counter}", (i, j));
                counter++;
            }
        }
    }

    public void ResetBoard()
    {
        Initialize();
    }

    public void UpdateBoard(string position, Player.PlayerCharacter character)
    {
        var (row, column) = _positionDictionary[position];
        _board[row, column] = character.ToString();
        _positionDictionary.Remove(position);
    }

    public bool IsPositionAvailable(string position)
    {
        return _positionDictionary.ContainsKey(position);
    }

    public void DisplayBoard()
    {
        Console.Clear();
        for (var i = 0; i < 3; i++)
        {
            Console.Write("|");
            for (var j = 0; j < 3; j++)
            {
                Console.Write(_board[i, j]);
                Console.Write("|");
            }

            Console.WriteLine();
        }
    }

    public bool IsWinner(Player.PlayerCharacter character)
    {
        var characterString = character.ToString();
        var isDiagonalX = 0;
        var isDiagonalY = 0;
        var isVertical = 0;
        var isHorizontal = 0;

        for (var i = 0; i < 3; i++)
        {
            if (_board[i, i].Equals(characterString))
            {
                isDiagonalX += 1;
            }

            if (_board[i, -(i - 2)].Equals(characterString))
            {
                isDiagonalY += 1;
            }

            if (isDiagonalX == 3 || isDiagonalY == 3)
            {
                return true;
            }

            for (var j = 0; j < 3; j++)
            {
                if (_board[j, i].Equals(characterString))
                {
                    isVertical += 1;
                }

                if (_board[i, j].Equals(characterString))
                {
                    isHorizontal += 1;
                }
            }

            if (isHorizontal == 3 || isVertical == 3)
            {
                return true;
            }

            isHorizontal = 0;
            isVertical = 0;
        }

        return false;
    }
    public bool IsDraw()
    {
        return _positionDictionary.Count == 0;
    }
}