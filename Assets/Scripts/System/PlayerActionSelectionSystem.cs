using System;

public class PlayerActionSelectionSystem : ISystem {
    Player localPlayer;
    Match match;

    public Game owner { get; set; }

    internal void Initialize () {
        UnityEngine.Debug.Log (string.Format ("owner: {0}", owner));
        this.match = owner.match;
        this.localPlayer = match.players.Find (player => player.controlMode == ControlMode.LOCAL);

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