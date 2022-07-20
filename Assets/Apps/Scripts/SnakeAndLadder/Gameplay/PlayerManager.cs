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
        public PersistentData PersistentData;
        [SerializeField] private GameObject playerPrefab;

        public event Action<PlayerLabel> OnSetTurn;

        private List<Player> playerList;
        public PlayerLabel turn;

        private void Awake() {
            playerList = new List<Player>();
            GeneratePlayer();
        }

        private void GeneratePlayer() {
            for (int i=0; i<PersistentData.playerCount; i++) {
                playerList.Add(Instantiate(playerPrefab, transform).GetComponent<Player>());
            }
        }

        internal Transform GetCurrentPlayer() {
            return playerList[((int)turn)].transform;
        }

        public void SetTurn(PlayerLabel playerLabel) {
            turn = playerLabel;

            OnSetTurn?.Invoke(playerLabel);
        }
    }
}
