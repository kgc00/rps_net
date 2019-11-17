using System.Collections.Generic;

public class Match {
    public const int PlayerCount = 2;

    public List<Player> players = new List<Player> (PlayerCount);

    public Match () {
        players.Add (new Player (0, ControlMode.LOCAL));
        players.Add (new Player (1, ControlMode.AI));
    }
}