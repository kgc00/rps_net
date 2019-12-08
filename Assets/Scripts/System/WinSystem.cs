using Assets.Scripts.Model;

namespace Assets.Scripts.System
{
    public class WinSystem : ISystem {
        public Game owner { get; set; }

        public void DetermineMatchEnded (RPS_Player winner) {
            if (winner == null) {
                // another round
            } else {
                // match is over
            }
        }
    }
}