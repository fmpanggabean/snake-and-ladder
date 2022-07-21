using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace SnakeAndLadder.Gameplay
{
    public class PlayerHUD : MonoBehaviour
    {
        public TMP_Text playerLabelText;
        public GameObject dimmer;

        private void Start() {
            SetAsHighlight(false);
        }

        public void SetLabel(PlayerLabel playerLabel) {
            playerLabelText.text = playerLabel.ToString();
        }
        public void SetAsHighlight(bool isHighlighted) {
            if (isHighlighted) {
                dimmer.SetActive(false);
            } else {
                dimmer.SetActive(true);
            }
        }
    }
}
