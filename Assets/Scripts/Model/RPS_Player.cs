using Assets.Scripts.Commands;
using Assets.Scripts.Enums;
using Assets.Scripts.Networking;
using Assets.Scripts.System;

namespace Assets.Scripts.Model
{
    public class RPS_Player
    {
        private NetworkClient networkClient;
        public ActionCommand actionCommand { get; private set; }
        public ControlMode controlMode { get; private set; }
        public string id { get; private set; }
        public RPS_Player(int id, ControlMode controlMode, NetworkClient networkClient = null)
        {
            this.actionCommand = null;
            this.id = "Player " + (1 + id);
            this.controlMode = controlMode;
            this.networkClient = networkClient;
        }

        public void SetRemoteAction(ActionType type)
        {
            actionCommand = ActionSystem.GenerateActionCommand(type, this);
        }

        public void GenerateNewAiAction()
        {
            actionCommand = ActionSystem.GenerateActionCommand(this);
        }

        public void GenerateNewPlayerAction(ActionType type)
        {
            actionCommand = ActionSystem.GenerateActionCommand(type, this);
            networkClient?.RaiseActionSelectedEvent(actionCommand);
        }

        public void ResetAction()
        {
            actionCommand = null;
        }
    }
}