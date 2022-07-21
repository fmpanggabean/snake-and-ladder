using System;
using System.Collections;
using UnityEngine;

namespace SnakeAndLadder.Gameplay {
    public class Player : MonoBehaviour {
        private Block block;
        public PlayerLabel PlayerLabel { set; get; }

        public event Action OnArrived;
        public event Action<PlayerLabel> OnLabelSet;

        internal void SetPosition(Block block) {
            transform.position = block.GetPosition();
            this.block = block;
        }

        internal void Move(int move) {
            StartCoroutine(Step(move));
        }

        private IEnumerator Step(int move) {
            while (move > 0) {
                Block nextBlock = block.GetNextBlock();
                if (nextBlock == null) {
                    Debug.Log("no next block");
                    break;
                } else {
                    SetPosition(nextBlock);
                    move--;
                }

                yield return new WaitForSeconds(0.3f);
            }
            OnArrived?.Invoke();
        }

        internal void SetLabel(PlayerLabel playerLabel) {
            PlayerLabel = playerLabel;
            OnLabelSet?.Invoke(PlayerLabel);
        }
    }
}