using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextGui : MonoBehaviour {

	GUIStyle TextStyle;


	// Use this for initialization
	void Start()
	{
		TextStyle = new GUIStyle();
		TextStyle.normal.textColor = Color.red;
		TextStyle.fontSize = 60;
	}

	// Update is called once per frame
	void Update()
	{

	}


	void OnGUI()
	{
		GUI.Label(new Rect(200, 40, 200, 40), "Points earned: " + AndroidBehaviour.points, TextStyle);
		GUI.Label(new Rect(200, 100, 200, 40), "Time remaining: " + System.Math.Round(AndroidBehaviour.timeRemaining), TextStyle);
	}
}
