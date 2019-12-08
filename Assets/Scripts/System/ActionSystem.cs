using System;
using Assets.Scripts.Commands;
using Assets.Scripts.Enums;
using Assets.Scripts.Model;

namespace Assets.Scripts.System
{
    public class ActionSystem : ISystem {

        Game ISystem.owner { get; set; }

        public static ActionCommand GenerateActionCommand (RPS_Player player) {
            // skip default option at end of enum
            var lengthOfValidEntries = Enum.GetNames (typeof (ActionType)).Length - 1;

            int rand = UnityEngine.Random.Range (0, lengthOfValidEntries);
            return new ActionCommand ((ActionType) rand, player);
        }

        public static ActionCommand GenerateActionCommand (ActionType actionType, RPS_Player player) {
            return new ActionCommand (actionType, player);
        }
    }
}