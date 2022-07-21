using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SnakeAndLadder.Gameplay
{
    public class PlayerHUDController : MonoBehaviour
    {
        [SerializeField]
        private GameObject playerHUDPrefab;

        [SerializeField]
        private List<Transform> playerHUDAnchor;

        [SerializeField]
        private PersistentData persistentData;

        private List<PlayerHUD> playerHUDs;

        private void Awake() {
            playerHUDs = new List<PlayerHUD>();

            GenerateHUD();
        }

        private void GenerateHUD() {
            for (int i = 0; i < persistentData.playerCount; i++) {
                playerHUDs.Add(Instantiate(playerHUDPrefab, playerHUDAnchor[i]).GetComponent<PlayerHUD>());
            }
        }
    }
}
