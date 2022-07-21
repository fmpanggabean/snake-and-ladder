using UnityEngine;
using System;
using System.Collections;

namespace SnakeAndLadder.Gameplay {
    internal class Player : MonoBehaviour {
        private Block Block;

        public event Action OnArrived;

        internal void SetPosition(Block block) {
            transform.position = block.GetPosition();
            Block = block;
        }

        internal void Move(int step) {
            StartCoroutine(MoveCoroutine(step));
        }

        private IEnumerator MoveCoroutine(int step) {
            int stepLeft = step;

            while (step > 0) {
                Block targetBlock = Block.GetNextBlock();

                Debug.Log(targetBlock);
                yield return UpdatePosition(targetBlock);
                step--;
            }
            OnArrived?.Invoke();
        }
        private IEnumerator UpdatePosition(Block target) {
            while (true) {
                transform.LookAt(target.GetPosition());
                transform.position += transform.forward * Time.deltaTime;

                if (Vector3.Distance(transform.position, target.GetPosition()) < 0.02f) {
                    break;
                }
                yield return null;
            }
            Block = target;
        }
    }
}