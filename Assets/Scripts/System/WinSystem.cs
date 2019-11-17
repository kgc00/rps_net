public class WinSystem : ISystem {
    public Game owner { get; set; }

    public void DetermineMatchEnded (Player winner) {
        if (winner == null) {
            // another round
        } else {
            // match is over
        }
    }
}