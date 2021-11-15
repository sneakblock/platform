using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CageManager : MonoBehaviour
{
    private GameObject capturedObject;

    [Range(0f, 1f)]
    public float mouseSens;

    //public GameObject cage;

    private void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
    }

    private void Update()
    {
        if (capturedObject != null)
        {
            capturedObject.GetComponent<Transform>().position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);
            capturedObject.GetComponent<Collider2D>().enabled = false;
            capturedObject.GetComponent<Rigidbody2D>().isKinematic = true;
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("Menu");
        }
    }

    public void CaptureObject(GameObject g)
    {
        if (capturedObject == null)
        {
            capturedObject = g;
            g.GetComponent<Collider2D>().enabled = false;
            g.GetComponent<Rigidbody2D>().isKinematic = true;
            Debug.Log("Captured" + g.name);
        } else
        {
            capturedObject.GetComponent<Transform>().position = g.GetComponent<Transform>().position;
            capturedObject.GetComponent<Collider2D>().enabled = true;
            capturedObject.GetComponent<Rigidbody2D>().isKinematic = false;
            capturedObject = g;
            g.GetComponent<Collider2D>().enabled = false;
            g.GetComponent<Rigidbody2D>().isKinematic = true;
            Debug.Log("Captured" + g.name);
        }
    }

}
