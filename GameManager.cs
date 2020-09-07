using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Game
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;
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
        public Text finalScore;

        public GameObject player;

        public int _score;
        public int _lives;

        public void ModifyScore(int value)
        {
            _score += value;
        }

        public int GetScore()
        {
            return _score;
        }

        public void ModifyLives(int value)
        {
            _lives -= value;
        }

        public int GetLives()
        {
            return _lives;
        }

        public void GameOver()
        {
            gameOver.SetActive(true);
            Destroy(player);
            finalScore.text = _score + " points X " + _lives + " lives = " + _score * _lives;
        }

        public void Restart()
        {
            gameOver.SetActive(false);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            _lives = 3;
            _score = 0;
            timer.timeRemaining = 100;
        }
    }
}
