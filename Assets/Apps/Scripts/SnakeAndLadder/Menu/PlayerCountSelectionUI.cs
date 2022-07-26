using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace SnakeAndLadder.Menu
{
    public class PlayerCountSelectionUI : MonoBehaviour
    {
        //button player selection
        public Button selectPlayer2;
        public Button selectPlayer3;
        public Button selectPlayer4;

        [SerializeField]
        private PersistentData PersistentData;

        private void Awake() {
            selectPlayer2.onClick.AddListener(Select2Player);
            selectPlayer3.onClick.AddListener(Select3Player);
            selectPlayer4.onClick.AddListener(Select4Player);
        }

        private void Select2Player() {
            PersistentData.playerQuantity = 2;
            ChangeSceneToGameplay();
        }
        private void Select3Player() {
            PersistentData.playerQuantity = 3;
            ChangeSceneToGameplay();
        }
        private void Select4Player() {
            PersistentData.playerQuantity = 4;
            ChangeSceneToGameplay();
        }
        private void ChangeSceneToGameplay() {
            SceneManager.LoadScene(1);
        }
    }
}
