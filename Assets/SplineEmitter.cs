using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplineEmitter : MonoBehaviour
{

    public float torqueAmount;

    public Spline spline1;
    public Spline spline2;

    public float minSplineDelta = .0001f;
    public float maxSplineDelta = .1f;

    public float minSecondsBeforeInitialExtension;
    public float maxSecondsBeforeInitialExtension;

    public float minSecondsBetweenRecurringExtensions;
    public float maxSecondsBetweenRecurringExtensions;

    public Transform splineSource1;
    public Transform splineSource2;

    private float secondsBeforeExtension;
    private float secondsBetweenRecurringExtensions;
    private Vector3 splineDelta;

    private void Start()
    {
        spline1.gameObject.GetComponent<Transform>().parent.localScale = new Vector3(0, 1, 1);
        spline2.gameObject.GetComponent<Transform>().parent.localScale = new Vector3(0, 1, 1);
        splineDelta = new Vector3(Random.Range(minSplineDelta, maxSplineDelta), 0, 0);
        secondsBeforeExtension = Random.Range(minSecondsBeforeInitialExtension, maxSecondsBeforeInitialExtension);
        secondsBetweenRecurringExtensions = Random.Range(minSecondsBetweenRecurringExtensions, maxSecondsBetweenRecurringExtensions);
        InvokeRepeating("Extend", secondsBeforeExtension, secondsBetweenRecurringExtensions);
   
    }

    void Extend()
    {
        spline1.Extend(splineDelta);
        spline2.Extend(splineDelta);
        Debug.Log("Extending with " + splineDelta + "splineDelta.");
    }

}
