using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class PlayerController : MonoBehaviour
    {
        Rigidbody2D rbRect;

        public int moveSpeed;

        private void Start()
        {
            rbRect = GetComponentInChildren<Rigidbody2D>();
        }

        private void Update()
        {
            float hor = Input.GetAxis("Horizontal");

            rbRect.velocity = new Vector2(hor * moveSpeed, 0);
        }
    }
}
