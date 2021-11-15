using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class SquarePuller : MonoBehaviour
{

    private GameObject[] otherSquares;

    public Color StandardColor;
    public Color ToColor;

    public float attractForce;

    [Range(1, 60)]
    public float minPullFuse;

    [Range(1, 60)]
    public float maxPullFuse;

    [Range(5, 60)]
    public float minPullRate;

    [Range(5, 60)]
    public float maxPullRate;

    [Range(1, 10)]
    public float pullDuration;

    [Range(0, 5)]
    public float riseRate;

    private float pullFuse;
    private float pullRate;
    private Vector3 riseRateVector3;

    public bool isPushing = false;



    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().color = StandardColor;
        pullFuse = Random.Range(minPullFuse, maxPullFuse);
        pullRate = Random.Range(minPullRate, maxPullRate);
        riseRateVector3 = new Vector3(0, riseRate, 0);
        InvokeRepeating("PullSquares", pullFuse, pullRate);
    }

    void PullSquares()
    {
        //Debug.Log("Pulling squares.");
        otherSquares = GameObject.FindGameObjectsWithTag("square");
        StartCoroutine(Puller());
        StartCoroutine(ColorChange());
        StartCoroutine(Kinematicer());
    }

    IEnumerator Puller()
    {
        isPushing = true;
        float timer = 0;
        while (timer < pullDuration)
        {
            transform.position += riseRateVector3;
            for (int i = 0; i < otherSquares.Length; i++)
            {
                if (otherSquares[i] != null && !otherSquares[i].GetComponent<SquarePuller>().isPushing)
                {
                    otherSquares[i].GetComponent<Rigidbody2D>().AddForce((transform.position - otherSquares[i].transform.position).normalized * attractForce);
                }
            }
            timer += Time.deltaTime;
            yield return null;
        }
        isPushing = false;
        
    }

    IEnumerator ColorChange()
    {
        GetComponent<SpriteRenderer>().color = ToColor;
        yield return new WaitForSeconds(pullDuration);
        GetComponent<SpriteRenderer>().color = StandardColor;
    }

    IEnumerator Kinematicer()
    {
        GetComponent<Rigidbody2D>().isKinematic = true;
        GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        yield return new WaitForSeconds(pullDuration);
        GetComponent<Rigidbody2D>().isKinematic = false;
    }
}
