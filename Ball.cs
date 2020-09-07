using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class Ball : MonoBehaviour
    {
        public GameObject rect;
        public AudioSource hitSound;

        Vector3 ballPosition;
        Vector3 ballPositionStart;

        Rigidbody2D rb;

        public bool isBallMoving;
        public Vector2 ballStartSpeed;

        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            ballPositionStart.y = transform.position.y;
        }

        private void Update()
        {
            if (!isBallMoving)
            {
                ballPosition.x = rect.transform.position.x;
                transform.position = new Vector2(ballPosition.x, ballPositionStart.y);

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    rb.isKinematic = false;

                    isBallMoving = true;
                    rb.AddForce(ballStartSpeed * 10);
                }
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (isBallMoving)
            {
                if (collision.collider.CompareTag("ColliderLeft"))
                {
                    if (rb.velocity.x > 0)
                    {
                        hitSound.Play();
                        rb.velocity = new Vector2(0, 0);
                        rb.AddForce(new Vector2((-ballStartSpeed.x + 8) * 10, ballStartSpeed.y * 10));
                    }
                    else if (rb.velocity.x < 0)
                    {
                        hitSound.Play();
                        rb.velocity = new Vector2(0, 0);
                        rb.AddForce(new Vector2((-ballStartSpeed.x - 5) * 10, ballStartSpeed.y * 10));
                    }
                }


                if (collision.collider.CompareTag("ColliderRight"))
                {
                    if (rb.velocity.x > 0)
                    {
                        hitSound.Play();
                        rb.velocity = new Vector2(0, 0);
                        rb.AddForce(new Vector2((ballStartSpeed.x + 5) * 10, ballStartSpeed.y * 10));
                    }
                    else if (rb.velocity.x < 0)
                    {
                        hitSound.Play();
                        rb.velocity = new Vector2(0, 0);
                        rb.AddForce(new Vector2((ballStartSpeed.x - 8) * 10, ballStartSpeed.y * 10));
                    }
                }

                if (collision.collider.CompareTag("Player"))
                {
                    hitSound.Play();
                }

                if (collision.collider.CompareTag("Walls"))
                {
                    hitSound.Play();
                }

                if (collision.collider.CompareTag("Blocks"))
                {
                    hitSound.Play();
                }

                if (collision.collider.CompareTag("Death"))
                {
                    isBallMoving = false;
                    GameManager.Instance.ModifyLives(1);
                    rb.velocity = new Vector2(0, 0);

                    rb.isKinematic = true;
                }
            }
        }
    }
}
