using UnityEngine;

public class Player : MonoBehaviour
{
    public int x { get; private set; }
    public int y { get; private set; }
    public Rigidbody2D rb { get; private set; }
    public CircleCollider2D colider { get; private set; }
    public Vector2Int moveInput { get; private set; }

    private State currentState;
    private LayerMask nodeLayer;

    private float moveSpeed = 5f;
    private float verticalSpeed = 10f;
    private float drillingSpeed = 3f;
    private float fuel = 100;

    private void Start()
    {
        nodeLayer = LayerMask.GetMask("Node");
        colider = GetComponent<CircleCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        transform.position = new Vector3(10, 200, 0);
        currentState = new Idle(this);
    }

    private void Update()
    {
        moveInput = new Vector2Int(Mathf.RoundToInt(Input.GetAxisRaw("Horizontal")), Mathf.RoundToInt(Input.GetAxisRaw("Vertical")));
        x = Mathf.RoundToInt(transform.position.x);
        y = Mathf.RoundToInt(transform.position.y);
        currentState.Loop();
    }
    private void FixedUpdate()
    {
        currentState.FixedLoop();
    }
    public void SetState(State state)
    {
        if (currentState != null)
        {
            currentState.OnStateExit();
        }

        currentState = state;

        if (currentState != null)
        {
            currentState.OnStateEnter();
        }
    }
    public void DrainFuel(float amount)
    {
        fuel -= amount * Time.deltaTime;
    }
    public bool IsGrounded()
    {
        return Physics2D.OverlapBox(transform.position - new Vector3(0, .5f), new Vector2(.3f, .02f), 0, nodeLayer);
    }
    public float GetHorizontalSpeed()
    {
        return this.moveSpeed;
    }
    public float GetVerticalSpeed()
    {
        return this.verticalSpeed;
    }
    public float GetDrillingSpeed()
    {
        return this.drillingSpeed;
    }
}
