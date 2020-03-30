using UnityEngine;
using UnityEngine.UI;
public class UI : MonoBehaviour
{
	private IShop deliveryShop;

	private void Start()
	{
		deliveryShop = transform.GetChild(0).GetComponent<IShop>();
		Player.Instance.onShopEntered += ShowShop;
		Player.Instance.onShopExit += HideShop;
		HideShop();
	}

	private void ShowShop(string shop)
	{
		switch (shop)
		{
			case "Delivery Shop":
				deliveryShop.Show();
				break;
		}
	}
	private void HideShop()
	{
		deliveryShop.Close();
	}
}
