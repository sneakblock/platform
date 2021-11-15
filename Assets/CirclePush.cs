using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CirclePush : MonoBehaviour
{

    private GameObject[] otherCircles;

    public Color StandardColor;
    public Color ToColor;

    public float repulseForce;

    [Range(1, 60)]
    public float minPullFuse;

    [Range(1, 60)]
    public float maxPullFuse;

    [Range(5, 60)]
    public float minPullRate;

    [Range(5, 60)]
    public float maxPullRate;

    [Range(1, 10)]
    public float pushDuration;

    //[Range(0, 5)]
    //public float fallRate;

    private float pullFuse;
    private float pullRate;
    //private Vector3 riseRateVector3;

    public bool isPushing = false;



    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().color = StandardColor;
        pullFuse = Random.Range(minPullFuse, maxPullFuse);
        pullRate = Random.Range(minPullRate, maxPullRate);
        //riseRateVector3 = new Vector3(0, riseRate, 0);
        InvokeRepeating("PushCircles", pullFuse, pullRate);
    }

    void PushCircles()
    {
        //Debug.Log("Pushing circles.");
        otherCircles = GameObject.FindGameObjectsWithTag("circle");
        StartCoroutine(Puller());
        StartCoroutine(ColorChange());
        StartCoroutine(Kinematicer());
    }

    IEnumerator Puller()
    {
        isPushing = true;
        float timer = 0;
        while (timer < pushDuration)
        {
            //transform.position += riseRateVector3;
            for (int i = 0; i < otherCircles.Length; i++)
            {
                if (otherCircles[i] != null && !otherCircles[i].GetComponent<CirclePush>().isPushing)
                {
                    otherCircles[i].GetComponent<Rigidbody2D>().AddForce(((otherCircles[i].transform.position) - transform.position).normalized * repulseForce);
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
        yield return new WaitForSeconds(pushDuration);
        GetComponent<SpriteRenderer>().color = StandardColor;
    }

    IEnumerator Kinematicer()
    {
        GetComponent<Rigidbody2D>().isKinematic = true;
        GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        yield return new WaitForSeconds(pushDuration);
        GetComponent<Rigidbody2D>().isKinematic = false;
    }
}
