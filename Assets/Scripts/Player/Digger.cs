using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Digger : MonoBehaviour
{
    public static int x { get; private set; }
    public static int y { get; private set; }
    public static Rigidbody2D rb { get; private set; }
    public static CircleCollider2D colider { get; private set; }

    private State currentState;

    private void Start()
    {
        colider = GetComponent<CircleCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        transform.position = new Vector3(10, 200, 0);
        currentState = new Idle(this);
    }

    private void Update()
    {
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

}
