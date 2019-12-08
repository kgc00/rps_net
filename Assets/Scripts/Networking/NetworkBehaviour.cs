using UnityEngine;

namespace Assets.Scripts.Networking
{
    public class NetworkBehaviour : MonoBehaviour {
        NetworkClient networkClient;
        void Start () {
            networkClient = new NetworkClient ();
            networkClient.CallConnect ();
        }

        void Update () {
            networkClient.OnUpdate ();
        }
    }
}