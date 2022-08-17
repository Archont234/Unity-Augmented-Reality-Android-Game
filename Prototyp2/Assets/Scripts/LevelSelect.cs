using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour {

	public Button LevelButton;
	public static string Level;

	// Use this for initialization
	void Start()
	{
		LevelButton = this.GetComponent<Button>();
	}

	// Update is called once per frame
	void Update()
	{
		if (EventSystem.current.currentSelectedGameObject.name == "Easy")
			Level = "Easy";

		else if (EventSystem.current.currentSelectedGameObject.name == "Medium")
			Level = "Medium";

		else if (EventSystem.current.currentSelectedGameObject.name == "Hard")
			Level = "Hard";
	}

	public void LoadGame()
	{
		SceneManager.LoadScene("MainGame_GhostsScene");
	}

	public void LoadMenu()
	{
		SceneManager.LoadScene("StartMenuScene");
	}
}
