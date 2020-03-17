using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
	private Digger digger;
	private Vector3 followPos;
	private void Start()
	{
		digger = FindObjectOfType<Digger>();
	}

	private void LateUpdate()
	{
		followPos = new Vector3(digger.transform.position.x, digger.transform.position.y, -10f);
		transform.position = followPos;
	}
}
