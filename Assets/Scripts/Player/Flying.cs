using UnityEngine;

public class Flying : State
{
	private Vector2 moveInput;
	private float hSpeed = 5f;
	private float vSpeed = 10f;
	private float enableGravityTimer = 1f;
	public Flying (Digger digger) : base(digger)
	{

	}
	public override void Loop()
	{
		
	}

	public override void FixedLoop()
	{
		moveInput.x = Input.GetAxis("Horizontal");
		moveInput.y = Input.GetAxis("Vertical");

		Vector2 move = new Vector2(moveInput.x * hSpeed, Mathf.Clamp(moveInput.y, 0, 1) * vSpeed);
		Digger.rb.MovePosition(Digger.rb.position + move * Time.fixedDeltaTime);
		if(GridManager.Instance.DiggerIsGrounded() && enableGravityTimer <= 0)
		{
			digger.SetState(new Idle(digger));
		}
		enableGravityTimer -= Time.fixedDeltaTime;
	}
	public override void OnStateEnter()
	{
		Debug.Log("Entered flying");
	}
}
