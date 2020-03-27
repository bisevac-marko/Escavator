using UnityEngine;

public class GridManager : MonoBehaviour
{
    private int gridWidth = 20;
    private int gridHeight = 200;

    private GameObject worldTextParent;
    private GameObject nodeParent;
    private GameObject[,] worldNodes;
    public static GridManager Instance { get; private set; }
    private Player player;
    public void GenerateGrid(NodeGenerator nodeGenerator)
    {
        Instance = this;
        worldTextParent = new GameObject("World Text");
        nodeParent = new GameObject("Nodes");
        player = FindObjectOfType<Player>();
        worldNodes = new GameObject[gridWidth, gridHeight];


        for (int x = 0; x < gridWidth; x++)
        {
            for (int y = 0; y < gridHeight; y++)
            {
                worldNodes[x, y] = Instantiate(nodeGenerator.GetRandom(y), new Vector3(x, y), Quaternion.identity, nodeParent.transform);
                worldNodes[x, y].name = "World_Node " + x + ", " + y;
                CreateWorldText(x + ", " + y, x, y);
            }
        }
    }

    public void DestroyNode(int posX, int posY)
    {
        Destroy(worldNodes[posX, posY]);
        worldNodes[posX, posY] = null;
    }
    public bool CanDrill(Vector2Int dir)
    {
        return player.IsGrounded() && NodeExists(dir) && TouchingNode(dir);
    }
    private bool NodeExists(Vector2Int dir)
    {
        int nodeX = player.x + dir.x;
        int nodeY = player.y + dir.y;
        if (nodeX < gridWidth && nodeX >= 0 && nodeY < gridHeight && nodeY >= 0)
        {
            if (worldNodes[nodeX, nodeY] != null)
            {
                return true;
            }
        }
        return false;
    }
    private bool TouchingNode(Vector2Int dir)
    {
        if (dir.x == 1)
        {
            return player.transform.position.x >= player.x;
        }
        else if (dir.x == -1)
        {
            return player.transform.position.x <= player.x;
        }
        
        if (dir.y == -1)
        {
            return player.transform.position.y <= player.y;
        }
        else if (dir.y == 1)
        {
            return player.transform.position.y >= player.y;
        }
        return false;
    }
    public void CreateWorldText(string text, int x, int y)
    {
        GameObject go = new GameObject("World_Text", typeof(TextMesh));
        go.transform.position = new Vector3(x, y);
        go.transform.SetParent(worldTextParent.transform);
        TextMesh textMesh = go.GetComponent<TextMesh>();
        textMesh.text = text;
        textMesh.anchor = TextAnchor.MiddleCenter;
        textMesh.alignment = TextAlignment.Center;
        textMesh.characterSize = 0.1f;
        textMesh.fontSize = 14;
        textMesh.color = Color.white;
    }
}
