using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
	private Image fuelBar;

	private void Awake()
	{
		fuelBar = transform.Find("Fuel Bar").transform.Find("Bar").GetComponent<Image>();
	}
}
