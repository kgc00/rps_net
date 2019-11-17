public class Player {
    public ActionCommand actionCommand { get; private set; }
    public ControlMode controlMode { get; private set; }
    public string id { get; private set; }
    public Player (int id, ControlMode controlMode) {
        this.actionCommand = null;
        this.id = "Player " + (1 + id);
        this.controlMode = controlMode;
    }

    public void GenerateNewAIAction () {
        actionCommand = ActionSystem.GenerateActionCommand (this);
    }

    public void GenerateNewPlayerAction (ActionType type) {
        actionCommand = ActionSystem.GenerateActionCommand (type, this);
    }

    public void ResetAction () {
        actionCommand = null;
    }
}