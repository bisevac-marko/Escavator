using System;
using UnityEngine;
using UnityEngine.UI;

public class UI_Money : MonoBehaviour
{
	private Text textMoney;

	private void Start()
	{
		textMoney = GetComponent<Text>();
		Player.Instance.onMoneyChange += UpdateMoneyText;
		textMoney.text = "0$";
	}

	private void UpdateMoneyText(float money)
	{
		textMoney.text = money.ToString() + "$";
	}
}
