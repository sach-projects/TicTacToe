public class Player{

    public enum PlayerCharacter{
        X ,
        O
    }

    public string Name { get; }
    public PlayerCharacter Character { get; }

    public Player(string playerName, PlayerCharacter playerCharacter){
        Name = playerName;
        Character = playerCharacter;
    }



}