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

        public PersistentData PersistentData;
        [SerializeField] private GameObject playerPrefab;

        public event Action<PlayerLabel> OnSetTurn;
        public event Action<PlayerLabel> OnNextTurn;

        private List<Player> playerList;

        public PlayerLabel turn;

        private void Awake() {
            playerList = new List<Player>();
            GeneratePlayer();
            GenerateEvent();
        }

        private void GenerateEvent() {
            for (int i = 0; i < PersistentData.playerCount; i++) {
                playerList[i].OnArrived += NextTurn;
            }
        }

        internal void Move(int move) {
            GetCurrentPlayer().Move(move);
        }

        private void NextTurn() {
            int turn = ((int)this.turn) + 1;
            if (turn >= 4) {
                turn = 0;
            }
            OnNextTurn?.Invoke((PlayerLabel)turn);
            //this.turn = (PlayerLabel)turn;
        }

        private void GeneratePlayer() {
            for (int i=0; i<PersistentData.playerCount; i++) {
                playerList.Add(Instantiate(playerPrefab, transform).GetComponent<Player>());
                playerList[i].SetPosition(World.GetBlock(1));
                playerList[i].SetLabel((PlayerLabel)i);
            }
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
