using UnityEngine;
using System.Collections;

public class SpawnFood : MonoBehaviour {
    // Food Prefab
    public GameObject foodPrefab;
    public GameObject poisonPrefab;
    float width;

    // Borders
    public Transform borderTop;
    public Transform borderBottom;
    public Transform borderLeft;
    public Transform borderRight;

    // Use this for initialization
    void Start () {
        width = 60;
        Camera.main.orthographicSize = (width / Screen.width) * Screen.height;
        print(Screen.width);
        // Spawn food every 4 seconds, starting in 3
        InvokeRepeating("Spawn", 3, 4);
        InvokeRepeating("Spawnp", 4, 6);
    }

    // Spawn one piece of food
    void Spawn() {
        // x position between left & right border
        int x = (int)Random.Range(borderLeft.position.x,
                                  borderRight.position.x);

        // y position between top & bottom border
        int y = (int)Random.Range(borderBottom.position.y,
                                  borderTop.position.y);

        // Instantiate the food at (x, y)
        Instantiate(foodPrefab,
                    new Vector2(x, y),
                    Quaternion.identity); // default rotation
    }
    void Spawnp()
    {
        // x position between left & right border
        int x = (int)Random.Range(borderLeft.position.x,
                                  borderRight.position.x);

        // y position between top & bottom border
        int y = (int)Random.Range(borderBottom.position.y,
                                  borderTop.position.y);

        // Instantiate the food at (x, y)
        Instantiate(poisonPrefab,
                    new Vector2(x, y),
                    Quaternion.identity); // default rotation
    }
}