using UnityEngine;
public class GameBehaviour : MonoBehaviour {
    Game game;
    void Awake () {
        game = GameFactory.Create ();
    }

    void Update () {
        game.OnUpdate ();
    }
}