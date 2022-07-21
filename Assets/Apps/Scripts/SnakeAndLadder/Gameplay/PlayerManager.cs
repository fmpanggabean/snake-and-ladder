using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SnakeAndLadder.Gameplay
{
    public class PlayerManager : MonoBehaviour
    {
        public GameObject playerPrefab;

        private List<Player> PlayerList = new List<Player>();

        private void Awake() {
            GeneratePlayer();
        }

        private void GeneratePlayer() {
            for(int i=0; i<PersistentData.playerQuantity; i++) {
                GameObject go = Instantiate(playerPrefab, transform);
                Player player = go.GetComponent<Player>();

                PlayerList.Add(player);
            }
        }
    }
}
