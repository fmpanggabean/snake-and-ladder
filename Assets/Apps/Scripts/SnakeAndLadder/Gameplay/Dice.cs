using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace SnakeAndLadder.Gameplay
{
    public class Dice : MonoBehaviour
    {
        public event Action OnDiceStart;
        public event Action<int> OnRandomize;
        public event Action OnRandomizeEnd;
        public event Action<int> OnDiceEnd;

        public int minValue;
        public int maxValue;
        [SerializeField]
        private int diceValue;

        private void Update() {
            if (Input.GetKeyDown(KeyCode.Space)) {
                Roll();
            }
        }
        public void Roll() {
            OnDiceStart?.Invoke();
        }
        internal void StartRollingDice() {
            StartCoroutine(RollingDice());
        }
        internal void EndRollingDice() {
            OnDiceEnd?.Invoke(diceValue);
        }
        private IEnumerator RollingDice() {
            float time = 2f;

            while (time > 0) {
                diceValue = UnityEngine.Random.Range(minValue, maxValue + 1);
                OnRandomize?.Invoke(diceValue);
                yield return new WaitForSeconds(0.1f);
                time -= 0.1f;
            }
            yield return new WaitForSeconds(1f);
            OnRandomizeEnd?.Invoke();
        }
    }
}
