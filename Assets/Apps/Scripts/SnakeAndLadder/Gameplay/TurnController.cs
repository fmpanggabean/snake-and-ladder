using System;
using UnityEngine;

namespace SnakeAndLadder.Gameplay {
    public enum PlayerLabel {
        Player_1, Player_2, Player_3, Player_4
    }
    [Serializable]
    internal class TurnController : MonoBehaviour {
        private GameManager GameManager => FindObjectOfType<GameManager>();
        public PlayerLabel Current { private set; get; }

        [SerializeField]
        private PersistentData PersistentData;

        public event Action<PlayerLabel> OnPlayerTurnSet;

        private void Awake() {
            OnPlayerTurnSet += GameManager.Highlight;
            OnPlayerTurnSet += GameManager.SetCameraToPlayer;
        }
        internal void Set(PlayerLabel playerLabel) {
            Current = playerLabel;
            OnPlayerTurnSet?.Invoke(Current);
        }
        internal void Next() {
            if (((int)Current) == PersistentData.playerQuantity-1) {
                Set(0);
            } else {
                Set(Current+1);
            }
        }
    }
}