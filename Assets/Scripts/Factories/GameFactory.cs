using Assets.Scripts.Model;
using Assets.Scripts.Networking;
using Assets.Scripts.System;

namespace Assets.Scripts.Factories
{
    public static class GameFactory {

        public static Game Create () {
            Game game = new Game ();

            // Add Systems
            var playerActionSelectionSystem = game.AddSystem<PlayerActionSelectionSystem> ();
            playerActionSelectionSystem.Initialize ();

            return game;
        }
    }
}