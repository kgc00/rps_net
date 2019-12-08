using Assets.Scripts.Model;
using Assets.Scripts.System;

namespace Assets.Scripts.State
{
    public class ComparisonState : GameState {
        bool returnToSelecting;
        public ComparisonState (Match match) : base (match) { }
        public override void OnEnter () {
            var winner = ActionComparisonSystem.DetermineWinner (
                match.Players[0].actionCommand,
                match.Players[1].actionCommand
            );
            if (winner != null) {
                UnityEngine.Debug.Log (string.Format ("winner is {0}", winner.id));
            } else {
                UnityEngine.Debug.Log (string.Format ("no winner"));
                returnToSelecting = true;
            }
        }

        public override GameState OnUpdate () {
            if (returnToSelecting) {
                foreach (RPS_Player player in match.Players) {
                    player.ResetAction ();
                }
                return new SelectingState (match);
            }

            return null;
        }
    }
}