using System.Collections.Generic;

public class ComparisonState : GameState {
    bool returnToSelecting;
    public ComparisonState (Match match) : base (match) { }
    public override void OnEnter () {
        var winner = ActionComparisonSystem.DetermineWinner (
            match.players[0].actionCommand,
            match.players[1].actionCommand
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
            foreach (Player player in match.players) {
                player.ResetAction ();
            }
            return new SelectingState (match);
        }

        return null;
    }
}