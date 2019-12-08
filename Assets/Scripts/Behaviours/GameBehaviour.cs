using Assets.Scripts.Factories;
using Assets.Scripts.Model;
using UnityEngine;

namespace Assets.Scripts.Behaviours
{
    public class GameBehaviour : MonoBehaviour {
        Game game;

        void Awake () {
            game = GameFactory.Create ();
        }
        void Update () {
            game.OnUpdate ();
        }
    }
}