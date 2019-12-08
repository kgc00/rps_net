using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Enums;
using Assets.Scripts.Model;
using ExitGames.Client.Photon;
using Photon.Realtime;
using UnityEngine;
using static Assets.Scripts.Networking.NetworkClient;

namespace Assets.Scripts.State
{
    public class SelectingState : GameState
    {
        private readonly List<RPS_Player> players;

        public SelectingState(Match match) : base(match)
        {
            players = match.Players;
            OnRemoteActionSelected += HandleRemoteSelection;
        }

        ~SelectingState()
        {
            OnRemoteActionSelected -= HandleRemoteSelection;
        }

        public override void OnEnter()
        {
            foreach (var player in players)
            {
                if (player.controlMode == ControlMode.AI)
                {
                    player.GenerateNewAiAction();
                }
            }
        }

        void HandleRemoteSelection(EventData photonEvent)
        {
            // 245 custom event content
            var data = (Hashtable) photonEvent[245];
            if (data.ContainsKey("commandSelected"))
            {
                players.FirstOrDefault(player => player.controlMode == ControlMode.REMOTE)
                    ?.SetRemoteAction((ActionType) data["commandSelected"]);
            }
            else
            {
                Debug.Log("not able to get info from command");
            }
        }

        public override GameState OnUpdate()
        {
            if (players.All(player => player.actionCommand != null))
            {
                return new ComparisonState(match);
            }

            return null;
        }
    }
}