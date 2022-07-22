using UnityEngine;
using System;
using System.Collections;

namespace SnakeAndLadder.Gameplay {
    public class Player : MonoBehaviour {
        private Block Block;
        private EffectorBlockSource effectorBlockSource;
        public PlayerLabel PlayerLabel;

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

                //Debug.Log(targetBlock);
                if (targetBlock == null) {
                    break;
                }
                
                yield return UpdatePosition(targetBlock);

                step--;
            }
            OnArrived?.Invoke();
        }
        private IEnumerator UpdatePosition(Block target) {
            while (true) {
                transform.LookAt(target.GetPosition());
                transform.position += transform.forward * Time.deltaTime * 5;

                if (Vector3.Distance(transform.position, target.GetPosition()) < 0.02f) {
                    break;
                }
                yield return null;
            }
            Block = target;
        }

        internal bool IsOnEffector() {
            if (effectorBlockSource == null) {
                return false;
            }
            return true;
        }

        internal void SetLabel(PlayerLabel label) {
            PlayerLabel = label;
        }

        private void OnTriggerEnter(Collider collider) {
            if (collider.GetComponent<EffectorBlockSource>()) {
                effectorBlockSource = collider.GetComponent<EffectorBlockSource>();
            }
        }
        private void OnTriggerExit(Collider collider) {
            if (collider.GetComponent<EffectorBlockSource>()) {
                effectorBlockSource = null;
            }
        }

        public void ApplyEffector() {
            SetPosition(effectorBlockSource.GetDestination());
        }
    }
}