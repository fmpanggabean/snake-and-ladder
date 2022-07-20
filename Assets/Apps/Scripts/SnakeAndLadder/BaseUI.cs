using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SnakeAndLadder
{
    public class BaseUI : MonoBehaviour
    {
        public void Show() {
            gameObject.SetActive(true);
        }
        public void Hide() {
            gameObject.SetActive(false);
        }
    }
}
