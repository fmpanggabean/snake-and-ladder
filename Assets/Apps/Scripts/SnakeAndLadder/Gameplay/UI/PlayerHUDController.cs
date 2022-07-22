using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SnakeAndLadder.Gameplay
{
    public class PlayerHUDController : MonoBehaviour
    {
        private PlayerManager PlayerManager => FindObjectOfType<PlayerManager>();
        private TurnController TurnController => FindObjectOfType<TurnController>();

        [SerializeField]
        private PersistentData PersistentData;
        [SerializeField]
        private Transform[] anchors;

        public GameObject playerHUDPrefab;

        private List<PlayerHUD> playerHUDList;

        private void Awake() {
            playerHUDList = new List<PlayerHUD>();

            PlayerManager.OnPlayerGenerated += GenerateHUD;
            TurnController.OnPlayerTurnSet += Highlight;
        }

        private void Highlight(PlayerLabel playerLabel) {
            for (int i = 0; i < playerHUDList.Count; i++) {
                if (((int)playerLabel) == i) {
                    playerHUDList[i].Highlight(true);
                } else {
                    playerHUDList[i].Highlight(false);
                }
            }
        }

        private void GenerateHUD(List<Player> playerList) {
            for (int i=0; i<playerList.Count; i++) {
                playerHUDList.Add(Instantiate(playerHUDPrefab, anchors[i]).GetComponent<PlayerHUD>());
                playerHUDList[i].SetLabel((PlayerLabel)i);
            }
        }
    }
}
