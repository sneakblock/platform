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

    public float rectWidthAndHeight;
    private Rect validArea;

    public Transform rectSource;
    
    

    // Start is called before the first frame update
    void Start()
    {

        validArea = new Rect(rectSource.position.x, rectSource.position.y, rectWidthAndHeight, rectWidthAndHeight);

        numSquares = Random.Range(minPerShapeSpawnRange, maxPerShapeSpawnRange);
        numCircles = Random.Range(minPerShapeSpawnRange, maxPerShapeSpawnRange);
        numDiamonds = Random.Range(minPerShapeSpawnRange, maxPerShapeSpawnRange);

        squares = new GameObject[numSquares];
        circles = new GameObject[numCircles];
        diamonds = new GameObject[numDiamonds];

        

        initSquares();
        initDiamonds();
        initCircles();


        
        
    }

    private void initCircles()
    {
        for (int i = 0; i < numCircles; i++)
        {
            circles[i] = GameObject.Instantiate(Circle, spawner.GetComponent<SpawnZone>().SpawnPoint, Quaternion.identity, transform);
        }
    }

    void initSquares()
    {
        for (int i = 0; i < numSquares; i++)
        {
            squares[i] = GameObject.Instantiate(Square, spawner.GetComponent<SpawnZone>().SpawnPoint, Quaternion.identity, transform);
        }
    }

    void initDiamonds()
    {
        for (int i = 0; i < numDiamonds; i++)
        {

            diamonds[i] = GameObject.Instantiate(Diamond, spawner.GetComponent<SpawnZone>().SpawnPoint, Quaternion.identity, transform);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireCube(new Vector3(validArea.center.x, validArea.center.y, .01f), new Vector3(validArea.size.x, validArea.size.y, .01f));
    }

    private void Update()
    {
        foreach (GameObject g in squares)
        {
            if (g != null && !validArea.Contains(new Vector2(g.transform.position.x, g.transform.position.y)))
            {
                Destroy(g);
            }
        }

        foreach (GameObject g in diamonds)
        {
            if (g != null && !validArea.Contains(new Vector2(g.transform.position.x, g.transform.position.y)))
            {
                Destroy(g);
            }
        }
    }



}
