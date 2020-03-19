using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Digger : MonoBehaviour
{
    public static int X { get; private set; }
    public static int Y { get; private set; }

    private State currentState;
    private LayerMask nodeLayerMask;
    private Rigidbody2D rb;

    private void Start()
    {
        transform.position = new Vector3(-1, 1000, 0);
        nodeLayerMask = LayerMask.GetMask("Node");
        rb = GetComponent<Rigidbody2D>();
        currentState = new Idle(this);
    }

    private void Update()
    {
        X = Mathf.RoundToInt(transform.position.x);
        Y = Mathf.RoundToInt(transform.position.y);
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
    public bool IsGrounded()
    {
        bool isGrounded = Physics2D.OverlapBox(new Vector2(X, Y - .55f), new Vector2(.9f, .1f), 0, nodeLayerMask);
        return isGrounded;
    }

}
