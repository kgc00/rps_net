using Assets.Scripts.Enums;
using Assets.Scripts.Model;

namespace Assets.Scripts.System
{
    public class PlayerActionSelectionSystem : ISystem {
        private RPS_Player localPlayer;
        private Match match;

        public Game owner { get; set; }

        internal void Initialize () {
            this.match = owner.match;
            // find player by id rather than control mode
            // OR assign control mode based on some params
            this.localPlayer = match.Players.Find (player => player.controlMode == ControlMode.LOCAL);

            if (localPlayer == null) return;
            ButtonEventSender.onChooseRock += SelectRock;
            ButtonEventSender.onChoosePaper += SelectPaper;
            ButtonEventSender.onChooseScissors += SelectScissors;
        }

        ~PlayerActionSelectionSystem () {
            if (localPlayer == null) return;
            ButtonEventSender.onChooseRock -= SelectRock;
            ButtonEventSender.onChoosePaper -= SelectPaper;
            ButtonEventSender.onChooseScissors -= SelectScissors;
        }
        public void SelectRock () => localPlayer.GenerateNewPlayerAction (ActionType.ROCK);
        public void SelectPaper () => localPlayer.GenerateNewPlayerAction (ActionType.PAPER);
        public void SelectScissors () => localPlayer.GenerateNewPlayerAction (ActionType.SCISSORS);
    }
}