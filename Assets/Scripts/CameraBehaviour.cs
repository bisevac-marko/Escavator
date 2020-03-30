using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
	private Player digger;
	private void Start()
	{
		digger = FindObjectOfType<Player>();
	}

	private void LateUpdate()
	{
		transform.position = new Vector3(9.5f, digger.transform.position.y, -10f);
	}
}
