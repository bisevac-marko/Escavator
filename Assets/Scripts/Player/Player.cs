using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int x { get; private set; }
    public int y { get; private set; }
    public Rigidbody2D rb { get; private set; }
    public CircleCollider2D colider { get; private set; }
    public Vector2Int moveInput { get; private set; }
    public float horizontalSpeed { get; private set; } = 15f;
    public float verticalSpeed { get; private set; } = 30f;
    public float drillingSpeed { get; private set; } = 3f;

    public delegate void OnFuelChange(float currentFuel);
    public event OnFuelChange onFuelChange;
    public delegate void OnMoneyChange(float currentFuel);
    public event OnMoneyChange onMoneyChange;
    public delegate void OnDamageTaken(int life);
    public event OnDamageTaken onDamageTaken;
    public delegate void OnShopEntered(string shop);
    public event OnShopEntered onShopEntered;
    public delegate void OnShopExit();
    public event OnShopExit onShopExit;

    private State currentState;
    private LayerMask nodeLayer;
    private List<Node> backPack;

    private float fuelUiUpdateTime = 2f;
    private float fuel;
    private float maxFuel = 1000f;

    private float money = 0;

    private int currentCapacity;
    private int maxCapacity = 5;

    private int life = 100;
    public static Player Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        backPack = new List<Node>();
        fuel = 1000;
        nodeLayer = LayerMask.GetMask("Node");
        colider = GetComponent<CircleCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        transform.position = new Vector3(10, GridManager.Instance.GetHeight(), 0);
        currentState = new Idle(this);
    }

    private void Update()
    {
        moveInput = new Vector2Int(Mathf.RoundToInt(Input.GetAxisRaw("Horizontal")), Mathf.RoundToInt(Input.GetAxisRaw("Vertical")));
        x = Mathf.RoundToInt(transform.position.x);
        y = Mathf.RoundToInt(transform.position.y);
        currentState.Loop();

        if(fuelUiUpdateTime <= 0)
        {
            onFuelChange?.Invoke(fuel);
            fuelUiUpdateTime = 2f;
        }
        fuelUiUpdateTime -= Time.deltaTime;
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
    public void AddToBackpack(Node node)
    {
        if (currentCapacity + 1 <= maxCapacity)
        {
            currentCapacity += 1;
            backPack.Add(node);
        }
    }
    public void ResetCapacity()
    {
        currentCapacity = 0;
        backPack.Clear();
    }
    public void CashoutNodes()
    {
        if (currentCapacity != 0)
        {
            foreach (Node n in backPack)
            {
                money += n.value;
            }
            onMoneyChange?.Invoke(money);
            ResetCapacity();
        }
    }
    public void TryFillFuel()
    {
        float currentFuelCost = maxFuel * GM.fuelCost;
        if (money >= currentFuelCost)
        {
            print("TEST?");
            //Fill fuel
            fuel = maxFuel;
            onFuelChange?.Invoke(fuel);
            money -= currentFuelCost;
            onMoneyChange?.Invoke(money);
        }
    }
    public void TakeDamage(int damage)
    {
        life -= damage;
        onDamageTaken?.Invoke(life);
        print(life);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        onShopEntered?.Invoke(collision.gameObject.transform.tag);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        onShopExit?.Invoke();
    }
}
