using Assets.Scripts.Model;

namespace Assets.Scripts.State
{
    public abstract class GameState {
        protected Match match;
        public GameState (Match match) { this.match = match; }
        public virtual void OnEnter () { }
        public virtual GameState OnUpdate () { return null; }
        public virtual void OnExit () { }
    }
}