using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SnakeAndLadder.Gameplay
{
    public class PlayerManager : MonoBehaviour
    {
        public PersistentData PersistentData;
        [SerializeField] private GameObject playerPrefab;

        private List<Player> playerList;

        private void Awake() {
            playerList = new List<Player>();
        }
        private void Start() {
            GeneratePlayer();
        }

        private void GeneratePlayer() {
            for (int i=0; i<PersistentData.playerCount; i++) {
                playerList.Add(Instantiate(playerPrefab, transform).GetComponent<Player>());
            }
        }
    }
}
