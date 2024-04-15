using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

namespace MovingBall
{
    public class MovingBall : MonoBehaviour
    {
        [SerializeField]
        Button pause;
        Rigidbody2D ball;
        float speed = 25.0f;
        // BreakingBlocks.BreakingBlocks breakingBlocks = new BreakingBlocks.BreakingBlocks();
        void Start()
        {
            ball = GetComponent<Rigidbody2D>();
        }

        /*bool IsPlaying()
        {
            if (play.enabled)
            {
                return true;
            }
            else
            {
                return false;
            }
        }*/

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "platform")
            {
                float x = (transform.position.x - collision.transform.position.x) / collision.collider.bounds.size.x;
                Vector2 dir = new Vector2(x, 1).normalized;
                ball.velocity = dir * speed;
            }
            if (collision.gameObject.tag == "loseBorder")
            {
                Destroy(gameObject);
            }
            
        }
        //public int Score() { return score; }
        // Update is called once per frame
        void Update()
        {
        }
    }
}
