using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    float speed = 10f;
    private bool movingRight = true;
    private GameObject enemy;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (movingRight)
        {
            gameObject.transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        else
        {
            gameObject.transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
            
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if((collision.gameObject.tag == "border" | collision.gameObject.tag == "enemy") & movingRight)
        {
            movingRight = false;
        }
        else if ((collision.gameObject.tag == "border" | collision.gameObject.tag == "enemy") & !movingRight)
        {
            movingRight = true;
        }
    }
}
