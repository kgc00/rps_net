// using System.Collections;

using Assets.Scripts.Commands;
using ExitGames.Client.Photon;
using Photon.Realtime;
using UnityEngine;
using System;
using Assets.Scripts.Enums;
using Assets.Scripts.Model;

// It is best practice to extend the LoadBalancingClient to modify callbacks and react to updates coming from the server.
namespace Assets.Scripts.Networking
{
    // game logic
    public class NetworkClient : LoadBalancingClient
    {
        public NetworkPlayer NetworkPlayer { get; }
        public static Action<EventData> OnRemoteActionSelected = delegate { };

        public NetworkClient() : base()
        {
            NetworkPlayer = new NetworkPlayer("someNickname", UnityEngine.Random.Range(0, 999), true);
            StateChanged += OnStateChanged;
        }

        // call this to connect to Photon
        public void CallConnect()
        {
            this.AppId = "57ac615e-8072-4b57-87a4-359811bd6746"; // set your app id here
            this.AppVersion = "1.0"; // set your app version here

            if (!this.ConnectToRegionMaster("usw")) // can return false for errors
            {
                this.DebugReturn(DebugLevel.ERROR, "Can't connect to: " + this.CurrentServerAddress);
            }
            UnityEngine.Debug.Log(string.Format("initiating connection"));
        }

        private void OnStateChanged(ClientState fromState, ClientState toState)
        {
            //Debug.Log ($"state changed {toState}");
            switch (toState)
            {

                case ClientState.ConnectedToNameServer:
                    break;
                case ClientState.ConnectedToGameServer:
                    break;
                case ClientState.ConnectedToMasterServer:
                    CallJoinOrCreateRoom();
                    break;
                case ClientState.Joined:
                    Debug.Log(string.Format("Have joined game"));
                    break;
            }
        }

        private void CallJoinOrCreateRoom()
        {
            var roomParams = new EnterRoomParams
            {
                RoomName = "someRoom",
                RoomOptions = new RoomOptions() { MaxPlayers = 2 },
                Lobby = TypedLobby.Default,
                CreateIfNotExists = true
            };
            OpJoinOrCreateRoom(roomParams);
        }

        public void RaiseActionSelectedEvent(ActionCommand actionCommand)
        {
            Debug.Log(string.Format("raising event"));
            byte eventCode = 9; // make up event codes at will
            Hashtable evData = new Hashtable
            {
                { "commandSelected", (int)actionCommand.action },
                { "player", actionCommand.owner.id}
            };
            var success = OpRaiseEvent(eventCode, evData, RaiseEventOptions.Default, SendOptions.SendUnreliable);
            Debug.Log($"success val: {success}");
        }

        public override void OnEvent(EventData photonEvent)
        {
            // important to call, to keep state up to date
            base.OnEvent(photonEvent);
            // we have defined two event codes, let's determine what to do
            switch (photonEvent.Code)
            {
                case 1:
                    // do something
                    Debug.Log($"event has been received {photonEvent.Code}");
                    //Debug.Log ($"event has been received {photonEvent.CustomData}");
                    //Debug.Log ($"event has been received {photonEvent.Parameters.ToStringFull()}");
                    //Debug.Log ($"event has been received {photonEvent.CustomDataKey}");
                    break;
                case 2:
                    Debug.Log($"event has been received {photonEvent.Code}");
                    // do something else
                    break;
                case 9:
                    OnRemoteActionSelected(photonEvent);
                    break;
            }
        }

        bool CallCreateRoom(string roomName, byte maxPlayers)
        {
            Debug.Log(string.Format("creating room"));
            EnterRoomParams roomParams = new EnterRoomParams
            {
                RoomName = roomName,
                RoomOptions = new RoomOptions() { MaxPlayers = maxPlayers },
                Lobby = TypedLobby.Default,
                CreateIfNotExists = true
            };
            return this.OpCreateRoom(roomParams);
        }

        bool CallJoinRoom()
        {
            OpJoinRandomRoomParams opJoinRandomRoomParams = new OpJoinRandomRoomParams() { };

            opJoinRandomRoomParams.ExpectedMaxPlayers = 2;

            // joining a random room with the map we selected before
            return this.OpJoinRandomRoom(opJoinRandomRoomParams);
        }

        void CallDisconnect()
        {
            if (IsConnectedAndReady)
            {
                this.Disconnect();
            }
        }

        public void OnUpdate()
        {
            this.Service();
        }
    }
}