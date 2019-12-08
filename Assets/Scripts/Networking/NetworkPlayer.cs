using ExitGames.Client.Photon;
using Photon.Realtime;

namespace Assets.Scripts.Networking
{
    // "Player in Room"
    public class NetworkPlayer : Player
    {
        protected internal NetworkPlayer(string nickName, int actorNumber, bool isLocal) : base(nickName, actorNumber, isLocal)
        {
        }

        protected internal NetworkPlayer(string nickName, int actorNumber, bool isLocal, Hashtable playerProperties) : base(nickName, actorNumber, isLocal, playerProperties)
        {
        }
    }
}