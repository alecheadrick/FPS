using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot2 : MonoBehaviour {
	public GameObject shotPoint;
	public float shotForce = 2.0f;

    public float explosiveForce = 10.0f;
    public float explosionRadius = 5.0f;

    public GameObject explosion;
    public AudioClip explodeNoise;

    public int health = 100;
    public Explode dieScript;

    public GameObject shotPuff;
	public GameObject muzzleFlash;
    public GameObject collider;
    public GameObject target;
    public float damage;

    public float rechargeTime = 0.1f;
	public float range = 500f;
    public float ammoLeft;
    public float maxAmmo = 10;


    public AudioClip machineGunSound;
	public AudioClip ricochetSound;

	private float lastShotTime;

	void Start() {
		lastShotTime = Time.time - rechargeTime;
        GameManager.ammoCount = ammoLeft;
    }

	// Update is called once per frame
	void Update () {
        GameManager.ammoCount = ammoLeft;

        if (Input.GetKeyDown("r"))
        {
            if (ammoLeft != maxAmmo)
            {
                ammoLeft = maxAmmo;
                GameManager.ammoCount = ammoLeft;
            }
        }

        if (Input.GetAxis("Fire1") > 0 && Time.time > lastShotTime + rechargeTime) {
            if (GameManager.ammoCount > 0)
            {
                Shoot();
            }
            GameManager.ammoCount = ammoLeft;
        }
	}

	void Shoot () {

		GameManager.shots++;
        ammoLeft--;

        lastShotTime = Time.time;
		RaycastHit info;

		if (muzzleFlash != null) {
			GameObject flash = Object.Instantiate(muzzleFlash, shotPoint.transform.position, Quaternion.identity); 
			Destroy(flash, 0.5f);
		}
		if (machineGunSound != null) {
			AudioSource.PlayClipAtPoint (machineGunSound, shotPoint.transform.position, 1.0f);
		}

		//if(shotPuff != null && Physics.Raycast(this.transform.position, this.transform.forward * range,out info, range))
		//the particular gun model we're using, down (up * -1) is the barrel direction
		if(shotPuff != null && Physics.Raycast(this.transform.position, this.transform.up * -1 * range,out info, range))
		{
			if(info.collider.tag == "Target" || info.collider.tag == "Terrain")
			{
				Target target = info.transform.GetComponent<Target>();
				if (target != null)
				{
					target.TakeDamage(damage);
				}
				Vector3 hitSpot = info.point;   
				GameObject puff = Object.Instantiate(shotPuff, hitSpot, Quaternion.identity);
                if (info.collider.tag == "Target") {

                    GameManager.hits++;
                    if (health <= 0)
                    {
                        GameObject newExplosion = (GameObject)Instantiate(explosion);
                        newExplosion.transform.position = target.transform.position;
                        Object.Destroy(newExplosion, 4.0f);
                        Destroy(target);
                    }
}
                Destroy(puff, 1f);

                if (ricochetSound != null)
                {
                    AudioSource.PlayClipAtPoint(ricochetSound, hitSpot, 1.0f);
                    
                }
                Rigidbody rb = info.collider.gameObject.GetComponent<Rigidbody>();
                if (rb != null)
                    {
                        rb.AddExplosionForce(shotForce, hitSpot, 1.0f, 0, ForceMode.Impulse);
                    }
                }
			}
		}
	}





