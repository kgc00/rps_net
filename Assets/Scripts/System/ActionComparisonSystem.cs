public class ActionComparisonSystem : ISystem {
    public Game owner { get; set; }

    public static Player DetermineWinner (ActionCommand command1, ActionCommand command2) {
        UnityEngine.Debug.Log (string.Format ("command1 {0}", command1.action));
        UnityEngine.Debug.Log (string.Format ("command2 {0}", command2.action));
        if (command1.action == ActionType.DEFAULT || command2.action == ActionType.DEFAULT) {
            UnityEngine.Debug.LogError ("An action for comparison was not set");
            return null;
        }

        if (command1.action == ActionType.PAPER) {
            if (command2.action == ActionType.SCISSORS) {
                return command2.owner;
            } else if (command2.action == ActionType.ROCK) {
                return command1.owner;
            } else {
                // no winner
                return null;
            }
        }

        if (command1.action == ActionType.ROCK) {
            if (command2.action == ActionType.PAPER) {
                return command2.owner;
            } else if (command2.action == ActionType.SCISSORS) {
                return command1.owner;
            } else {
                // no winner
                return null;
            }
        }

        if (command1.action == ActionType.SCISSORS) {
            if (command2.action == ActionType.ROCK) {
                return command2.owner;
            } else if (command2.action == ActionType.PAPER) {
                return command1.owner;
            } else {
                // no winner
                return null;
            }
        }

        return null;
    }
}