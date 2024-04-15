using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Sounds : MonoBehaviour
{
    public AudioSource victory;
    public AudioSource lose;
    public AudioSource levelMusic;
    public AudioSource damageSound;
    public TextMeshProUGUI title;
    private Rigidbody2D ball;
    public GameObject menu;
    public GameObject blocks;
    public GameObject nextLevel;
    public GameObject rating;
    public GameObject returnInGame;
    public GameObject ballParet;
    public GameObject pause;
    void Start()
    {
      ball = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "block1" | collision.gameObject.tag == "block2" | 
            collision.gameObject.tag == "block3" | collision.gameObject.tag == "block4" | collision.gameObject.tag == "block5")
        {
            damageSound.Play();
        }
        if(collision.gameObject.tag == "loseBorder" & ballParet.transform.childCount == 1)
        {
            BreakingBlocks.score = BreakingBlocks.finalScore;
            levelMusic.Stop();
            menu.active = true;
            pause.active = false;
            returnInGame.active = false;
            rating.active = true;
            lose.Play();
            title.text = "  LOSE  ";
        }
        else if (blocks.transform.childCount == 1 & collision.gameObject.tag == "block1")
        {
            levelMusic.Stop();
            menu.active = true;
            nextLevel.active = true;
            rating.active = true;
            returnInGame.active = false;
            pause.active = false;
            victory.Play();
            title.text = "VICTORY";
            Destroy(ball);
            Destroy(collision.gameObject);
            BreakingBlocks.finalScore = BreakingBlocks.score;
        }

    }
}
