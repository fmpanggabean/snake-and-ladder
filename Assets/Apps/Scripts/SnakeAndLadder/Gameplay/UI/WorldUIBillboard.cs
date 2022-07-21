using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SnakeAndLadder.Gameplay
{
    public class WorldUIBillboard : MonoBehaviour
    {
        private Transform camera;

        private void Awake() {
            camera = Camera.main.transform;    
        }
        private void Update() {
            transform.LookAt(transform.position + camera.forward);
        }
    }
}
