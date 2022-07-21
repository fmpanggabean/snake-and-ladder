using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace SnakeAndLadder.Gameplay
{
    public class Dice : MonoBehaviour
    {
        public int low;
        public int high;

        public event Action<int> OnDiceThrow;
        public event Action OnDiceThrowStart;
        public event Action OnDiceThrowEnd;

        private void Update() {
            //test
            if (Input.GetKeyDown(KeyCode.Space)) {
                Throw();
            }
        }
        public void Throw() {
            int rand = GetRandomDice();
            Debug.Log(rand);
            StartCoroutine(Wait(rand));
        }
        private IEnumerator Wait(int rand) {
            OnDiceThrowStart?.Invoke();

            yield return new WaitForSeconds(2);

            OnDiceThrowEnd?.Invoke();
            OnDiceThrow?.Invoke(rand);
        }

        internal int GetRandomDice() {
            return UnityEngine.Random.Range(low, high + 1);
        }
    }
}
