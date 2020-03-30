using System;
using UnityEngine;
using UnityEngine.UI;

public class UI_Score : MonoBehaviour
{
	private Text scoreText;

	private void Start()
	{
		scoreText = GetComponent<Text>();
		GridManager.Instance.onNodeDrilled += UpdateScore;
	}

	private void UpdateScore(int nodeType)
	{
		float amount = 0;
		switch (nodeType)
		{
			case 0:
				amount = 80;
				break;
			case 1:
				amount = 250;
				break;
			case 2:
				amount = 350;
				break;
			case 3:
				amount = 600;
				break;
			case 4:
				amount = 900;
				break;
		}
		scoreText.text = (Int32.Parse(scoreText.text) + amount).ToString();
	}
}
