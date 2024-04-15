using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

    public class BreakingBlocks : MonoBehaviour
    {
        public NumberRenderer theScore;
        public GameObject[] bonus;
        public static int score;
        public static int finalScore;   
        int x;
        [SerializeField]
        Sprite green, blue, yellow, orange, red;
        public GameObject explosion, crack, crackPoint, explosionPoint;
        void Start()
        {
            //score = 0;
            theScore.RenderNumber(0);
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            x = Random.Range(0, bonus.Length * 2);
            switch (collision.gameObject.tag)
            {
                case "block1":
                    GameObject value = Instantiate(explosionPoint, transform.position, Quaternion.identity);
                    Destroy(value, 0.3f);
                    score += 20;
                    GameObject exp = Instantiate(explosion, transform.position, Quaternion.identity);
                    Destroy(exp, 3f);
                    Destroy(collision.gameObject);
                    bonus[x].active = true;
                    bonus[x].transform.position = collision.gameObject.transform.position;
                    break;
                case "block2":
                    collision.gameObject.tag = "block1";
                    value = Instantiate(crackPoint, transform.position, Quaternion.identity);
                    Destroy(value, 0.3f);
                    score += 5;
                    GameObject action = Instantiate(crack, transform.position, Quaternion.identity);
                    Destroy(action, 3f);
                    collision.gameObject.GetComponent<SpriteRenderer>().sprite = blue;
                    break;
                case "block3":
                    collision.gameObject.tag = "block2";
                    value = Instantiate(crackPoint, transform.position, Quaternion.identity);
                    Destroy(value, 0.3f);
                    score += 5;
                    action = Instantiate(crack, transform.position, Quaternion.identity);
                    Destroy(action, 3f);
                    collision.gameObject.GetComponent<SpriteRenderer>().sprite = green;
                    break;
                case "block4":
                    collision.gameObject.tag = "block3";
                    value = Instantiate(crackPoint, transform.position, Quaternion.identity);
                    Destroy(value, 0.3f);
                    score += 5;
                    action = Instantiate(crack, transform.position, Quaternion.identity);
                    Destroy(action, 3f);
                    collision.gameObject.GetComponent<SpriteRenderer>().sprite = yellow;
                    break;
                case "block5":
                    collision.gameObject.tag = "block4";
                    value = Instantiate(crackPoint, transform.position, Quaternion.identity);
                    Destroy(value, 0.3f);
                    score += 5;
                    action = Instantiate(crack, transform.position, Quaternion.identity);
                    Destroy(action, 3f);
                    collision.gameObject.GetComponent<SpriteRenderer>().sprite = orange;
                    break;
            }
        }
        // Update is called once per frame
        void Update()
        {
            theScore.RenderNumber(score);
        }
    }

