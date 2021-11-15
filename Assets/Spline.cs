using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spline : MonoBehaviour
{

    private Transform parent;
    private Transform diamondTransform;
    private float torqueAmount;

    public Color toColor;
    public Color standardColor;

    private void Start()
    {
        parent = transform.parent;
        diamondTransform = transform.parent.parent;
        torqueAmount = transform.parent.parent.gameObject.GetComponent<SplineEmitter>().torqueAmount;
    }

    public void Extend(Vector3 splineDelta)
    {
        StartCoroutine("BeginExtension", splineDelta);
    }

    IEnumerator BeginExtension(Vector3 splineDelta)
    {
        GetComponent<SpriteRenderer>().color = toColor;
        transform.parent.parent.GetComponent<SpriteRenderer>().color = toColor;
        //transform.parent.parent.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        int directionCoinFlip = (int)Mathf.Floor(Random.Range(0, 2));
        while (parent.localScale.x < 1)
        {
            parent.localScale += splineDelta;
            
            if (directionCoinFlip == 0) diamondTransform.Rotate(new Vector3(0, 0, torqueAmount));
            if (directionCoinFlip == 1) diamondTransform.Rotate(new Vector3(0, 0, -torqueAmount));
            yield return null;
        }
        

        StartCoroutine("BeginRetraction", splineDelta);
    }

    IEnumerator BeginRetraction(Vector3 splineDelta)
    {
        int directionCoinFlip = (int)Mathf.Floor(Random.Range(0, 2));
        while (parent.localScale.x > 0)
        {
            parent.localScale -= splineDelta;
            
            if (directionCoinFlip == 0) diamondTransform.Rotate(new Vector3(0, 0, torqueAmount));
            if (directionCoinFlip == 1) diamondTransform.Rotate(new Vector3(0, 0, -torqueAmount));
            yield return null;
        }
        GetComponent<SpriteRenderer>().color = standardColor;
        //transform.parent.parent.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        transform.parent.parent.GetComponent<SpriteRenderer>().color = standardColor;

    }

}
