using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shatterer : MonoBehaviour
{
    //public GameObject bullet;
    public float bulletForce;
    public float minSecondsBeforeFiring;
    public float maxSecondsBeforeFiring;
    public float minSecondsBetweenFiring;
    public float maxSecondsBetweenFiring;

    private Transform circleCenter;
    private float secondsBeforeFiring;
    private float secondsBetweenFiring;

    private void Start()
    {
        secondsBeforeFiring = Random.Range(minSecondsBeforeFiring, maxSecondsBeforeFiring);
        secondsBetweenFiring = Random.Range(minSecondsBetweenFiring, maxSecondsBetweenFiring);
        InvokeRepeating("FireBullet", secondsBeforeFiring, secondsBetweenFiring);
    }

    void FireBullet()
    {
        //GameObject bulletInstance= GameObject.Instantiate(bullet, transform.parent);
        //Physics2D.IgnoreCollision(bulletInstance.GetComponent<Collider2D>(), transform.parent.GetComponent<Collider2D>());
        //bulletInstance.GetComponent<Rigidbody2D>().AddForce(new Vector3(bulletForce, 0, 0));
        //StartCoroutine("despawnBullet", bulletInstance);
        transform.parent.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector3(bulletForce, 0, 0));
    }

    /*
    IEnumerator despawnBullet(GameObject bulletInstance)
    {
        yield return new WaitForSeconds(5);
        Destroy(bulletInstance);
    }
    */
}
