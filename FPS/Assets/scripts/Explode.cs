using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour {
	public float explosiveForce = 10.0f;
	public float explosionRadius = 5.0f;
    public int damage;

    public GameObject explosion; 
	public AudioClip explodeNoise;

    void OnTriggerEnter (Collider collision) {
        if (explosion != null)
        {

            GameObject newExplosion = (GameObject)Instantiate(explosion);
            newExplosion.transform.position = this.transform.position;
            Object.Destroy(newExplosion, 4.0f);
        }
		Target enemy = collision.transform.GetComponent<Target>();
		if (enemy != null)
		{
			enemy.TakeDamage(damage);
		}
		if (explodeNoise != null) {
			AudioSource.PlayClipAtPoint (explodeNoise, transform.position, 1.0f);
		}

		//Debug.Log ("Boom 1!");
		//this.GetComponent<Rigidbody>().AddExplosionForce(explosiveForce, transform.position, explosionRadius, 1.0f, ForceMode.Impulse);
		Rigidbody target = collision.GetComponent<Rigidbody>();
		if (target != null && collision.gameObject.tag != "Player") {
            GameManager.hits++;
            target.AddExplosionForce (explosiveForce, transform.position, explosionRadius, 1.0f, ForceMode.Impulse);

		}

		Object.Destroy (this.gameObject);
	}
}
