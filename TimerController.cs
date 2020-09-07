using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class TimerController : MonoBehaviour
    {
        public float timeRemaining = 100;


        private void Update()
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }

            else
            {
                timeRemaining = 0;
            }
        }
    }
}
