using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot3 : MonoBehaviour
{
    public float explosiveForce = 10.0f;
    public float explosionRadius = 5.0f;

    public GameObject explosion;
    public AudioClip explodeNoise;
    public GameObject hell;


    void OnTriggerEnter(Collider collision)
    {
        if (explosion != null)
        {
           // die.hitsToExplode = 0;
            GameObject newExplosion = (GameObject)Instantiate(explosion);
            newExplosion.transform.position = this.transform.position;
            Object.Destroy(newExplosion, 4.0f);
        }

        if (explodeNoise != null)
        {
            AudioSource.PlayClipAtPoint(explodeNoise, transform.position, 1.0f);
        }

        //Debug.Log ("Boom 1!");
        //this.GetComponent<Rigidbody>().AddExplosionForce(explosiveForce, transform.position, explosionRadius, 1.0f, ForceMode.Impulse);
        Rigidbody target = collision.GetComponent<Rigidbody>();
        if (target != null && collision.gameObject.tag != "Player")
        {
            GameManager.hits++;
            target.AddExplosionForce(explosiveForce, transform.position, explosionRadius, 1.0f, ForceMode.Impulse);
        }

        Object.Destroy(this.gameObject);
    }
}
