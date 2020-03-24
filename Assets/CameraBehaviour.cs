using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
	private Digger digger;
	private int boundLeft;
	private int boundRight;
	private void Start()
	{
		digger = FindObjectOfType<Digger>();
		boundLeft = 10;
		boundRight = 40;
		transform.position = digger.transform.position;
	}

	private void LateUpdate()
	{
		if (digger.transform.position.x >= boundLeft && digger.transform.position.x <= boundRight)
		{
			transform.position = new Vector3(digger.transform.position.x, digger.transform.position.y, -10f);
		}
		else
		{
			transform.position = new Vector3(transform.position.x, digger.transform.position.y, -10f);
		}
	}
}
