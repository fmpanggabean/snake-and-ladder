using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace SnakeAndLadder.Gameplay
{
    public class DiceUI : BaseUI
    {
        private Dice Dice => FindObjectOfType<Dice>();

        [SerializeField]
        private GameObject rollDiceWindow;
        [SerializeField]
        private TMP_Text diceText;
        [SerializeField]
        private Button rollButton;

        private IEnumerator diceCoroutine;

        private void Awake() {
            Dice.OnDiceThrowStart += ShowRandomDice;
            Dice.OnDiceThrowEnd += StopRandomDice;
            Dice.OnDiceThrow += ShowDice;
            rollButton.onClick.AddListener(Dice.Throw);

            diceCoroutine = RandomDice();

            //Hide();
            HideRollingDice();
        }

        private void HideRollingDice() {
            rollDiceWindow.gameObject.SetActive(false);
            rollButton.gameObject.SetActive(true);
        }
        private void ShowRollingDice() {
            rollDiceWindow.gameObject.SetActive(true);
            rollButton.gameObject.SetActive(false);
        }

        private void StopRandomDice() {
            StopCoroutine(diceCoroutine);
            StartCoroutine(DelayedHide());
        }

        private void ShowRandomDice() {
            ShowRollingDice();
            //Show();
            //rollButton.gameObject.SetActive(false);
            StartCoroutine(diceCoroutine);
        }
        private IEnumerator DelayedHide() {
            yield return new WaitForSeconds(1);
            //rollButton.gameObject.SetActive(true);
            //Hide();
            HideRollingDice();
        }
        private IEnumerator RandomDice() {
            while (true) {
                ShowDice(Dice.GetRandomDice());
                yield return new WaitForSeconds(0.1f);
            }
        }
        private void ShowDice(int value) {
            diceText.text = value.ToString();
        }
    }
}
