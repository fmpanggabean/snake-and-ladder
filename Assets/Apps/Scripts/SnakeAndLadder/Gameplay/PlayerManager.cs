using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SnakeAndLadder.Gameplay
{
    public class PlayerManager : MonoBehaviour
    {
        private World World => FindObjectOfType<World>();
        private Dice Dice => FindObjectOfType<Dice>();

        private List<Player> PlayerList = new List<Player>();

        public GameObject playerPrefab;

        public event Action OnPlayerArrived;

        public void Initialize() {
            GeneratePlayer();
            SetPlayerOnStartingPosition();
            SetPlayerEvent();
        }

        private void SetPlayerEvent() {
            PlayerList.ForEach((player) => player.OnArrived += PlayerArrived);
        }

        private void PlayerArrived() {
            Debug.Log("Arrived");
            OnPlayerArrived?.Invoke();
        }

        private void SetPlayerOnStartingPosition() {
            PlayerList.ForEach((player) => player.SetPosition(World.GetBlock(0)));
        }
        private void GeneratePlayer() {
            for (int i = 0; i < PersistentData.playerQuantity; i++) {
                GameObject go = Instantiate(playerPrefab, transform);
                Player player = go.GetComponent<Player>();

                PlayerList.Add(player);
            }
        }

        internal Player GetPlayer(PlayerLabel playerLabel) {
            return PlayerList[((int)playerLabel)];
        }
    }
}
