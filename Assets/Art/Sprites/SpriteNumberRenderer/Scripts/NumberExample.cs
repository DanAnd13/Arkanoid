using UnityEngine;
using System.Collections;

public class NumberExample : MonoBehaviour {


	public NumberRenderer theScore;
    //BreakingBlocks.BreakingBlocks points = new BreakingBlocks.BreakingBlocks();

	// Use this for initialization
	void Start () 
	{
		//This is the main render function. Give this fuction the number you want to render.
		//theScore.RenderNumber (0);
	}
	
	// Update is called once per frame
	void Update ()
	{
		//theScore.RenderNumber (points.score); //Render the score
	}
}
