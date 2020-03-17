using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Digger : MonoBehaviour
{
    public static int posX;
    public static int posY;

    private GameManager gridManager;
    private State currentState;

    private void Start()
    {
        gridManager = FindObjectOfType<GameManager>();
        currentState = new Idle(this);
    }

    private void Update()
    {
        posX = Mathf.RoundToInt(transform.position.x);
        posY = Mathf.RoundToInt(transform.position.y);
        currentState.Loop();
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
