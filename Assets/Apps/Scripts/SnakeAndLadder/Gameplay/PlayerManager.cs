using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SnakeAndLadder.Gameplay
{
    public enum PlayerLabel {
        Player1, Player2, Player3, Player4
    }
    public class PlayerManager : MonoBehaviour
    {
        private World World => FindObjectOfType<World>();
        private BlockEffectManager BlockEffectManager => FindObjectOfType<BlockEffectManager>();

        public PersistentData PersistentData;
        [SerializeField] private GameObject playerPrefab;

        public event Action<PlayerLabel> OnSetTurn;
        public event Action<PlayerLabel> OnPlayerArrived;
        public event Action<List<Player>> OnPlayerGenerated;

        private List<Player> playerList = new List<Player>();

        public PlayerLabel turn;

        private void Awake() {

            //GeneratePlayer();
            //GenerateEvent();
        }

        internal void Initialize() {
            GeneratePlayer();
            SetStartingPosition();
            GenerateEvent();
        }

        private void SetStartingPosition() {
            for (int i = 0; i < PersistentData.playerCount; i++) {
                playerList[i].SetPosition(World.GetBlock(1));
            }
        }
        private void GenerateEvent() {
            for (int i = 0; i < PersistentData.playerCount; i++) {
                playerList[i].OnArrived += PlayerArrived;
            }
        }
        private void GeneratePlayer() {
            for (int i=0; i<PersistentData.playerCount; i++) {
                playerList.Add(Instantiate(playerPrefab, transform).GetComponent<Player>());
                //playerList[i].SetPosition(World.GetBlock(1));
                playerList[i].SetLabel((PlayerLabel)i);
            }
            OnPlayerGenerated?.Invoke(playerList);
        }
        internal void Move(int move) {
            GetCurrentPlayer().Move(move);
        }
        private void PlayerArrived() {
            //evaluate block
            BlockEffectManager.Evaluate();

            int turn = ((int)this.turn) + 1;
            if (turn >= playerList.Count) {
                turn = 0;
            }
            OnPlayerArrived?.Invoke((PlayerLabel)turn);
        }
        internal Player GetCurrentPlayer() {
            return playerList[((int)turn)];
        }
        public void SetTurn(PlayerLabel playerLabel) {
            turn = playerLabel;

            OnSetTurn?.Invoke(playerLabel);
        }
    }
}
