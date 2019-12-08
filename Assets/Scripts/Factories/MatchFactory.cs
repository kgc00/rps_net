using Assets.Scripts.Model;

namespace Assets.Scripts.Factories
{
    public static class MatchFactory {
        public static Match Create () {
            Match match = new Match ();

            return match;
        }
    }
}