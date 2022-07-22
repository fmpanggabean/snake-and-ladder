using System;
using UnityEngine;
using TMPro;

namespace SnakeAndLadder.Gameplay {
    internal class PlayerHUD : MonoBehaviour {
        [SerializeField]
        private GameObject dimmer;
        [SerializeField]
        private TMP_Text playerLabelText;


        public void SetLabel(PlayerLabel playerLabel) {
            playerLabelText.text = playerLabel.ToString();
        }
        internal void Highlight(bool isHighlighted) {
            dimmer.SetActive(!isHighlighted);
        }
    }
}