using UnityEngine;

public class Flying : State
{
	private Vector2 moveInput;
	private float enableGravityTimer = 1f;
	private Vector3 gravity = new Vector3(0, -9.8f, 0);
	private float gravityScale = 20f;
	
	public Flying (Player player) : base(player)
	{

	}

	public override void FixedLoop()
	{
		moveInput.x = Input.GetAxis("Horizontal");
		moveInput.y = Input.GetAxis("Vertical");

		Vector2 move = new Vector2(moveInput.x * player.GetHorizontalSpeed(), Mathf.Clamp(moveInput.y, 0, 1) * player.GetVerticalSpeed());
		player.rb.MovePosition(player.rb.position + move * Time.fixedDeltaTime);
		if(player.IsGrounded() && enableGravityTimer <= 0)
		{
			player.SetState(new Idle(player));
		}
		enableGravityTimer -= Time.fixedDeltaTime;

		player.DrainFuel(3f);
	}
	public override void OnStateEnter()
	{
		player.rb.gravityScale = gravityScale;
		Physics2D.gravity = gravity;
	}

	public override void OnStateExit()
	{
		player.rb.gravityScale = 0;
		Physics2D.gravity = Vector3.zero;
	}
}
