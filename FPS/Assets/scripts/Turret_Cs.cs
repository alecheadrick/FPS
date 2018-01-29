using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret_Cs : MonoBehaviour {

	public Transform target;
	public Transform gun;
	public float turretDegreesPerSecond = 45.0f;
	public float gunDegreesPerSecond = 45.0f;

	public float maxGunAngle = 45.0f;

	private Quaternion qTurret;
	private Quaternion qGun;
	private Quaternion qGunStart;
	private Transform trans;

	void Start (){
		trans = transform;
		qGunStart = gun.transform.localRotation;
	}

	void Update (){
		if (GameObject.Find ("Done_Player") != null) {
			Debug.DrawRay (gun.position, gun.forward * 20.0f);
			float distanceToPlane = Vector3.Dot (trans.up, target.position - trans.position);
			Vector3 planePoint = target.position - trans.up * distanceToPlane;

			qTurret = Quaternion.LookRotation (planePoint - trans.position, transform.up);
			transform.rotation = Quaternion.RotateTowards (transform.rotation, qTurret, turretDegreesPerSecond * Time.deltaTime);

			Vector3 v3 = new Vector3 (0.0f, distanceToPlane, (planePoint - transform.position).magnitude);
			qGun = Quaternion.LookRotation (v3);

			if (Quaternion.Angle (qGunStart, qGun) <= maxGunAngle) {
				gun.localRotation = Quaternion.RotateTowards (gun.localRotation, qGun, gunDegreesPerSecond * Time.deltaTime);
		}

		}
	}
}