using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Bonus : MonoBehaviour
{
    float speed = 5f;
    public GameObject ball;
    public Transform ballParent;
    public GameObject shield;
    Vector2 start;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.tag == "platform" | collision.gameObject.tag == "ball") & gameObject.tag == "bonusShield")
        {
            Destroy(gameObject);
            shield.active=true;
        }
        else if ((collision.gameObject.tag == "platform" | collision.gameObject.tag == "ball") & gameObject.tag == "bonusX3")
        {
            Destroy(gameObject);
            start = new Vector2(0f, -8.75f).normalized;
            GameObject copyBall1 = Instantiate(ball);
            copyBall1.transform.parent = ballParent;
            copyBall1.transform.position = ball.transform.position;
            GameObject copyBall2 = Instantiate(ball);
            copyBall2.transform.parent = ballParent;
            start = new Vector2(-1f, -8.75f).normalized;
            copyBall2.transform.position = ball.transform.position;
            GameObject copyBall3 = Instantiate(ball);
            copyBall3.transform.parent = ballParent;
            start = new Vector2(1f, -8.75f).normalized;
            copyBall3.transform.position = ball.transform.position;
        }
        else if(collision.gameObject.tag == "ball" & gameObject.tag == "shield")
        {
            Destroy (gameObject);
        }
    }
}
