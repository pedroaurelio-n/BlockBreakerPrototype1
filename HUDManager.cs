using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class HUDManager : MonoBehaviour
    {
        public static HUDManager Instance;

        private void Awake()
        {
            if (!Instance)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }

            else
            {
                Destroy(gameObject);
            }
        }

        public GameObject gameOver;
        public TimerController timer;

        public Text scoreTxt;
        public Text livesTxt;
        public Text timerTxt;

        int blockNum;



        private void Start()
        {
            blockNum = GameObject.FindGameObjectsWithTag("Blocks").Length;
            scoreTxt.text = "Score: " + GameManager.Instance._score;
            livesTxt.text = "Lives: " + GameManager.Instance._lives;
            timerTxt.text = "" + timer.timeRemaining;
        }

        private void Update()
        {
            
            blockNum = GameObject.FindGameObjectsWithTag("Blocks").Length;

            scoreTxt.text = "Score: " + GameManager.Instance._score;
            livesTxt.text = "Lives: " + GameManager.Instance._lives;
            timerTxt.text = "" + Mathf.Round(timer.timeRemaining);

            if ((timer.timeRemaining <= 0 || GameManager.Instance._lives <=0) && gameOver.activeSelf == false)
            {
                GameManager.Instance._lives = 0;
                GameManager.Instance.GameOver();
            }

            if (blockNum <= 0)
            {
                GameManager.Instance.GameOver();
            }
        }
    }
}