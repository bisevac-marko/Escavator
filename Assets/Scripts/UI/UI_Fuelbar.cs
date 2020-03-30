using UnityEngine;
using UnityEngine.UI;

public class UI_Fuelbar : MonoBehaviour
{
	private Image barImage;

	private void Start()
	{
		barImage = transform.Find("Bar").GetComponent<Image>();
		Player.Instance.onFuelChange += UpdateBar;
	}

	private void UpdateBar(float amount)
	{
		barImage.fillAmount = (amount / 1000);
	}
}
