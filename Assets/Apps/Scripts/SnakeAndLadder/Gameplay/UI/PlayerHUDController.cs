using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SnakeAndLadder.Gameplay
{
    public class PlayerHUDController : MonoBehaviour
    {
        private PlayerManager PlayerManager => FindObjectOfType<PlayerManager>();

        [SerializeField]
        private GameObject playerHUDPrefab;

        [SerializeField]
        private List<Transform> playerHUDAnchor;

        [SerializeField]
        private PersistentData persistentData;

        private List<PlayerHUD> playerHUDs = new List<PlayerHUD>();

        private void Awake() {
            PlayerManager.OnPlayerGenerated += GenerateHUD;
        }

        private void GenerateHUD(List<Player> players) {
            for (int i = 0; i < persistentData.playerCount; i++) {
                PlayerHUD hud = Instantiate(playerHUDPrefab, playerHUDAnchor[i]).GetComponent<PlayerHUD>();
                hud.SetLabel(players[i].PlayerLabel);
                playerHUDs.Add(hud);
            }
        }
    }
}
