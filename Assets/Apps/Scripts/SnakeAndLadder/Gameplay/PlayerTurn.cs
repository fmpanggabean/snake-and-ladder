using System;
using UnityEngine;

namespace SnakeAndLadder.Gameplay {
    public enum PlayerLabel {
        Player_1, Player_2, Player_3, Player_4
    }
    [Serializable]
    internal class PlayerTurn {
        private GameManager GameManager;
        public event Action<PlayerLabel> OnPlayerTurnSet;
        public PlayerLabel Current { private set; get; }

        public PlayerTurn(GameManager gameManager) {
            this.GameManager = gameManager;

            OnPlayerTurnSet += GameManager.Highlight;
            OnPlayerTurnSet += GameManager.SetCameraToPlayer;
        }
        internal void Set(PlayerLabel playerLabel) {
            Current = playerLabel;
            OnPlayerTurnSet?.Invoke(Current);
        }
        internal void Next() {
            if (((int)Current) == 3) {
                Set(0);
            } else {
                Set(Current+1);
            }
        }
    }
}