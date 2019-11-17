using System.Collections.Generic;

public interface IContainer {
    T AddSystem<T> (string key = null) where T : ISystem, new ();
    T AddSystem<T> (T aspect, string key = null) where T : ISystem;
    T GetSystem<T> (string key = null) where T : ISystem;
    ICollection<ISystem> Systems ();
}

public class Game : IContainer {
    public Match match { get; private set; }
    public GameState state { get; private set; }
    Dictionary<string, ISystem> systems = new Dictionary<string, ISystem> ();

    public Game () {
        match = new Match ();
        state = new SelectingState (match);
        state.OnEnter ();
    }

    public T AddSystem<T> (string key = null) where T : ISystem, new () {
        return AddSystem<T> (new T (), key);
    }

    public T AddSystem<T> (T system, string key = null) where T : ISystem {
        key = key ?? typeof (T).Name;
        systems.Add (key, system);
        system.owner = this;
        return system;
    }

    public T GetSystem<T> (string key = null) where T : ISystem {
        key = key ?? typeof (T).Name;
        T aspect = systems.ContainsKey (key) ? (T) systems[key] : default (T);
        return aspect;
    }

    public ICollection<ISystem> Systems () {
        return systems.Values;
    }

    public void OnUpdate () {
        var newState = state?.OnUpdate ();
        if (newState != null) {
            UnityEngine.Debug.Log (string.Format ("state is: {0}", newState));
            state.OnExit ();
            state = newState;
            state.OnEnter ();
        }
    }
}