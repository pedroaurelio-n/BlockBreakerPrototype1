using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class BlocksManager : MonoBehaviour
    {
        public int scoreValue;
        public int hitCounter;

        public AudioClip pointSound;


        SpriteRenderer sprite;
        

        private void Start()
        {
            sprite = GetComponent<SpriteRenderer>();
        }


        private void Update()
        {
            if (hitCounter == 0)
            {
                AudioSource.PlayClipAtPoint(pointSound, transform.position);
                Destroy(gameObject);
                GameManager.Instance.ModifyScore(scoreValue);
            }
        }


        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.collider.CompareTag("Ball"))
            {
                hitCounter--;
                sprite.color -= new Color(0, 0, 0, 0.25f);
            }
        }
    }
}
