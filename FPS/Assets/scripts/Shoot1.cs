using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot1 : MonoBehaviour {
	public GameObject projectile;
	public GameObject shotPoint;
	public float shotForce = 8.0f;
	public float shotTTL = 5.0f;
	public float rechargeTime = 2.2f;
    public float ammoLeft;
    public float maxAmmo = 10;
    public float damage;

	public AudioClip launchNoise;

	private float lastShotTime;

    public void Start()
    {
        GameManager.ammoCount = ammoLeft;
    }
    // Update is called once per frame
    void Update () {
        GameManager.ammoCount = ammoLeft;
        if (Input.GetKeyDown("r"))
        {
            Debug.Log("pressing R");
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



		if (launchNoise != null) {
			AudioSource.PlayClipAtPoint (launchNoise, shotPoint.transform.position, 1.0f);
		}

		GameObject newshot = Object.Instantiate (projectile, 
			shotPoint.transform.position, 
			this.transform.rotation);
		
		newshot.GetComponent<Rigidbody>().AddForce(transform.up * shotForce, ForceMode.Impulse);


        Object.Destroy (newshot, shotTTL);
	}
}
