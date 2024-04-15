using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    float speed = 40f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(speed * Vector2.right * Input.GetAxis("Horizontal") * Time.deltaTime);
        transform.position = new Vector2 (Mathf.Clamp(transform.position.x, -21.0f, 21.0f), transform.position.y);
    }
}
