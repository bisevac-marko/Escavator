using UnityEngine;

public class UI_DeliveryShop : MonoBehaviour, IShop
{
	private GameObject mainMenu;
	private GameObject fuelMenu;
	private GameObject deliveryMenu;

	private void Start()
	{
		mainMenu = transform.Find("Main").gameObject;
		deliveryMenu = transform.Find("Delivery").gameObject;
		fuelMenu = transform.Find("Fuel").gameObject;

		ShowMainMenu();
	}
	public void ShowMainMenu()
	{
		fuelMenu.SetActive(false);

		deliveryMenu.SetActive(false);

		mainMenu.SetActive(true);

	}

	public void OpenFuelMenu()
	{
		mainMenu.SetActive(false);

		fuelMenu.SetActive(true);

	}
	public void OpenDeliveryMenu()
	{
		mainMenu.SetActive(false);

		deliveryMenu.SetActive(true);

	}

	public void Show()
	{
		gameObject.SetActive(true);
	}

	public void Close()
	{
		ShowMainMenu();
		gameObject.SetActive(false);
	}
}
