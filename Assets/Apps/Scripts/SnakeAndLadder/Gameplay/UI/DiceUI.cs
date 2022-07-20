using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace SnakeAndLadder.Gameplay
{
    public class DiceUI : BaseUI
    {
        private Dice Dice => FindObjectOfType<Dice>();

        [SerializeField] private TMP_Text diceText;
        private IEnumerator diceCoroutine;

        private void Awake() {
            Dice.OnDiceThrowStart += ShowRandomDice;
            Dice.OnDiceThrowEnd += StopRandomDice;
            Dice.OnDiceThrow += ShowDice;
        }

        private void Start() {
            Hide();
            diceCoroutine = RandomDice();
        }

        private void StopRandomDice() {
            StopCoroutine(diceCoroutine);
            StartCoroutine(DelayedHide());
        }

        private void ShowRandomDice() {
            Show();
            StartCoroutine(diceCoroutine);
        }
        private IEnumerator DelayedHide() {
            yield return new WaitForSeconds(1);
            Hide();
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
