using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Digger : MonoBehaviour
{
    public static int posX;
    public static int posY;

    private State currentState;

    private void Start()
    {
        transform.position = new Vector3(1, GameManager.startingHeight - 10, 0);
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
