using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Finish : MonoBehaviour
{
	Text scoreText;
	GameSession gameSession;
	int point=0;

	// Use this for initialization
	void Start()
	{
		scoreText = GetComponent<Text>();
		gameSession = FindObjectOfType<GameSession>();
		
	}

	// Update is called once per frame
	void Update()
	{
		scoreText.text = gameSession.GetScore().ToString();
		//Debug.Log(scoreText);
	}

}

