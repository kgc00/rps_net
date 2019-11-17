using System.Linq;
public class SelectingState : GameState {
    public SelectingState (Match match) : base (match) { }

    public override void OnEnter () {
        foreach (var player in base.match.players) {
            if (player.controlMode == ControlMode.AI) {
                player.GenerateNewAIAction ();
            }
        }
    }
    public override GameState OnUpdate () {
        if (match.players.All (player => player.actionCommand != null)) {
            return new ComparisonState (match);
        } else {
            return null;
        }
    }
}