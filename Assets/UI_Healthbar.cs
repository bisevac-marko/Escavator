using UnityEngine.UI;
using UnityEngine;
public class UI_Healthbar : MonoBehaviour
{
	private Image barImage;

	private void Start()
	{
		barImage = transform.Find("Bar").GetComponent<Image>();
		Player.Instance.onDamageTaken += UpdateBar;
	}

	private void UpdateBar(int life)
	{
		barImage.fillAmount = (life / 100f);
	}
}
