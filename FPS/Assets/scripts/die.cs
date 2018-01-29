using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class die : MonoBehaviour
{
    public float explosiveForce = 10.0f;
    public float explosionRadius = 5.0f;
    public int hitsToExplode = 100;
    public Explode damageScript;

    public GameObject explosion;
    public AudioClip explodeNoise;




    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "lightning shot(Clone)")
        {

            damageScript = other.gameObject.GetComponent<Explode>();
            hitsToExplode -= damageScript.damage;
            
            if (hitsToExplode <= 0)
            {
                GameObject newExplosion = (GameObject)Instantiate(explosion);
                newExplosion.transform.position = this.transform.position;
                Object.Destroy(newExplosion, 4.0f);
                Destroy(other.gameObject);
                Destroy(gameObject);
            }

        }
        if (other.gameObject.name == "Shot(Clone)")
        {
            damageScript = other.gameObject.GetComponent<Explode>();
            hitsToExplode -= damageScript.damage;

            if (hitsToExplode <= 0)
            {
                Debug.Log("should explode");
                GameObject newExplosion = (GameObject)Instantiate(explosion);
                newExplosion.transform.position = this.transform.position;
                Object.Destroy(newExplosion, 4.0f);
                Destroy(other.gameObject);
                Destroy(gameObject);
            }
        }
        //need to get this to work on shot 2
        if (other.gameObject.name == "Ricochet")
        {
            Debug.Log("trying to get damage");
            damageScript = other.gameObject.GetComponent<Explode>();
            hitsToExplode -= damageScript.damage;

            if (hitsToExplode <= 0)
            {
                GameObject newExplosion = (GameObject)Instantiate(explosion);
                newExplosion.transform.position = this.transform.position;
                Object.Destroy(newExplosion, 4.0f);
                Destroy(other.gameObject);
                Destroy(gameObject);
            }
        }
    }
}