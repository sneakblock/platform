using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class SquarePuller : MonoBehaviour
{

    private GameObject[] otherSquares;

    public int attractForce;

    [Range(1, 60)]
    public float minPullFuse;

    [Range(1, 60)]
    public float maxPullFuse;

    [Range(5, 60)]
    public float minPullRate;

    [Range(5, 60)]
    public float maxPullRate;

    private float pullFuse;
    private float pullRate;



    // Start is called before the first frame update
    void Start()
    {
        pullFuse = Random.Range(minPullFuse, maxPullFuse);
        pullRate = Random.Range(minPullRate, maxPullRate);
        otherSquares = GameObject.FindGameObjectsWithTag("square");
        InvokeRepeating("PullSqaures", pullFuse, pullRate);
    }

    void PullSquares()
    {
        for (int i = 0; i < otherSquares.Length; i++)
        {
            Rigidbody2D squareRB = otherSquares[i].GetComponent<Rigidbody2D>();
            squareRB.AddForce((otherSquares[i].transform.position - transform.position) * attractForce);
        }

    }
}
