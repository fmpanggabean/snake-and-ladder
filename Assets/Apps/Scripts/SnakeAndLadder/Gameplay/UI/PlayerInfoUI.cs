using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace SnakeAndLadder.Gameplay
{
    public class PlayerInfoUI : MonoBehaviour
    {
        private Player Player => gameObject.GetComponentInParent<Player>();

        [SerializeField] private TMP_Text nameText;

        private void Awake() {
            Player.OnLabelSet += SetName;
        }

        public void SetName(PlayerLabel playerLabel) {
            nameText.text = playerLabel.ToString();
        }
    }
}
