using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clicker : MonoBehaviour
{
    private CageManager cageManager;

    // Start is called before the first frame update
    void Start()
    {
        cageManager = GameObject.Find("cageManager").GetComponent<CageManager>();
    }

    private void OnMouseDown()
    {
        cageManager.CaptureObject(gameObject);
    }
}
