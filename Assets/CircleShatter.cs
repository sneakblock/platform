using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleShatter : MonoBehaviour
{
    public GameObject bullet;
    public float force;
    public float numberOfBullets;

    public float minSecondsToFire;
    public float maxSecondsToFire;

    public float minSecondsBetweenFiring;
    public float maxSecondsBetweenFiring;

    private GameObject[] bullets;
    private GameObject[] otherCircles;
    private float secondsToFire;
    private float secondsBetweenFiring;

    private void Start()
    {
        secondsToFire = Random.Range(minSecondsToFire, maxSecondsToFire);
        secondsBetweenFiring = Random.Range(minSecondsBetweenFiring, maxSecondsBetweenFiring);
        InvokeRepeating("FireBullets", secondsToFire, secondsBetweenFiring);
    }

    void FireBullets()
    {
        otherCircles = GameObject.FindGameObjectsWithTag("circle");
        for (int i = 0; i < numberOfBullets; i++)
        {
            Vector2 direction = Vector2.zero;
            if (otherCircles[i] != null)
            {
                direction = (this.transform.position - otherCircles[i].transform.position).normalized;
            }
            bullets[i] = GameObject.Instantiate(bullet, transform);
            Physics2D.IgnoreCollision(bullets[i].GetComponent<Collider2D>(), GetComponent<Collider2D>());
            if (direction != Vector2.zero)
            {
                bullets[i].GetComponent<Rigidbody2D>().AddForce(direction * force);
            }
            StartCoroutine(DestroyBullet(bullets[i]));
        }
    }

    IEnumerator DestroyBullet(GameObject bullet)
    {
        yield return new WaitForSeconds(3);
        Destroy(bullet);
    }

}
