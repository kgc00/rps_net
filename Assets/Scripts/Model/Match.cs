using System.Collections.Generic;
using Assets.Scripts.Enums;
using Assets.Scripts.Networking;

namespace Assets.Scripts.Model
{
    public class Match
    {
        public const int PlayerCount = 2;

        public List<RPS_Player> Players = new List<RPS_Player>(PlayerCount);

        public Match()
        {
            UnityEngine.Debug.Log("local");
            Players.Add(new RPS_Player(0, ControlMode.LOCAL));
            Players.Add(new RPS_Player(1, ControlMode.AI));
        }

        public Match(NetworkClient networkClient)
        {
            UnityEngine.Debug.Log("networked");
            Players.Add(new RPS_Player(0, ControlMode.LOCAL, networkClient));
            Players.Add(new RPS_Player(1, ControlMode.REMOTE, networkClient));
        }
    }
}