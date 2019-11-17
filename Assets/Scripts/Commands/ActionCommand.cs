public class ActionCommand {
    public ActionType action { get; private set; } = ActionType.DEFAULT;
    public Player owner { get; private set; }
    public ActionCommand (ActionType action, Player owner) {
        this.action = action;
        this.owner = owner;
    }
}