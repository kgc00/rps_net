using Assets.Scripts.Enums;
using Assets.Scripts.Model;

namespace Assets.Scripts.Commands
{
    public class ActionCommand {
        public ActionType action { get; private set; } = ActionType.DEFAULT;
        public RPS_Player owner { get; private set; }
        public ActionCommand (ActionType action, RPS_Player owner) {
            this.action = action;
            this.owner = owner;
        }
    }
}