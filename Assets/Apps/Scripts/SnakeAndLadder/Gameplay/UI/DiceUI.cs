using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace SnakeAndLadder.Gameplay
{
    public class DiceUI : MonoBehaviour {
        private Animator Animator => GetComponent<Animator>();
        private Dice Dice => FindObjectOfType<Dice>();
        
        private event Action OnUIShown;
        private event Action OnUIHidden;

        //component
        public TMP_Text TextRandomNumber;
        public Button ButtonRoll;

        private void Awake() {
            ButtonRoll.onClick.AddListener(Dice.Roll);

            Dice.OnDiceStart += ShowMenu;
            OnUIShown += Dice.StartRollingDice;
            OnUIHidden += Dice.EndRollingDice;
            Dice.OnRandomize += SetTextRandomNumber;
            Dice.OnRandomizeEnd += HideMenu;
            Dice.OnEnabled += EnableRollButton;
            Dice.OnDisabled += DisableRollButton;
        }

        private void EnableRollButton() {
            ButtonRoll.enabled = true;
        }

        private void DisableRollButton() {
            ButtonRoll.enabled = false;
        }

        private void SetTextRandomNumber(int rand) {
            TextRandomNumber.text = rand.ToString();
        }
        internal void ShowMenu() {
            StartCoroutine(ShowMenuCoroutine());
        }
        private IEnumerator ShowMenuCoroutine() {
            Hide(ButtonRoll.gameObject);
            Hide(TextRandomNumber.gameObject);

            Animator.SetTrigger("Show");
            while (Animator.GetCurrentAnimatorStateInfo(0).normalizedTime <= 1f || Animator.IsInTransition(0)) {
                yield return null;
            }
            Show(TextRandomNumber.gameObject);
            OnUIShown?.Invoke();
        }
        internal void HideMenu() {
            StartCoroutine(HideMenuCoroutine());
        }
        private IEnumerator HideMenuCoroutine() {
            Animator.SetTrigger("Hide");
            while (Animator.GetCurrentAnimatorStateInfo(0).normalizedTime <= 1f || Animator.IsInTransition(0)) {
                yield return null;
            }
            Show(ButtonRoll.gameObject);
            Hide(TextRandomNumber.gameObject);

            OnUIHidden?.Invoke();
        }
        private void Hide(GameObject gameObject) {
            gameObject.SetActive(false);
        }
        private void Show(GameObject gameObject) {
            gameObject.SetActive(true);
        }
    }
}
