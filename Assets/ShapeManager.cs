using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeManager : MonoBehaviour
{

    public GameObject spawner;

    [Range(1, 20)]
    public float spawnRange;

    public GameObject Square;
    public GameObject Circle;
    public GameObject Diamond;

    [Range(1, 20)]
    public int minPerShapeSpawnRange;

    [Range(1, 20)]
    public int maxPerShapeSpawnRange;

    private int numSquares;
    private int numCircles;
    private int numDiamonds;

    private GameObject[] squares;
    private GameObject[] circles;
    private GameObject[] diamonds;

    

    // Start is called before the first frame update
    void Start()
    {
        numSquares = Random.Range(minPerShapeSpawnRange, maxPerShapeSpawnRange);
        numCircles = Random.Range(minPerShapeSpawnRange, maxPerShapeSpawnRange);
        numDiamonds = Random.Range(minPerShapeSpawnRange, maxPerShapeSpawnRange);

        squares = new GameObject[numSquares];
        circles = new GameObject[numCircles];
        diamonds = new GameObject[numDiamonds];

        

        initSquares();
    }

    void initSquares()
    {
        for (int i = 0; i < numSquares; i++)
        {
            squares[i] = Square;
            GameObject.Instantiate(Square, spawner.GetComponent<SpawnZone>().SpawnPoint, Quaternion.identity, transform);
        }
    }
}
