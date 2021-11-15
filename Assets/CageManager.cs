using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CageManager : MonoBehaviour
{
    private GameObject capturedObject;

    public GameObject cage;

    private void Update()
    {
        cage.transform.position += new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
    }

}
