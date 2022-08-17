using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGameText : MonoBehaviour {

	public Text Highscore = null;

	// Use this for initialization
	void Start () {


		Highscore.text = "Score: " + AndroidBehaviour.points;
		Highscore.color = Color.white;
		Highscore.fontSize = 60;
	}
	
	// Update is called once per frame
	void Update () {

		
	}
}
