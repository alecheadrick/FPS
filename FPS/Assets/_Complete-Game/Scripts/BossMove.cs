using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMove : MonoBehaviour {
	public Transform[] path;
	public float speed = 5.0f;
	public float reachDist = 0f;
	public int currentPoint = 0;
	public bool doneForHere;


	public void doneValue(bool doneNow){
		doneForHere = doneNow;
	}


	void Start () {
		doneForHere = false;
	}

	// Update is called once per frame
	void Update () {
			Vector3 dir = path [currentPoint].position - transform.position;

			transform.position += dir * Time.deltaTime * speed;

			if (dir.magnitude <= reachDist) {
				currentPoint++;
			}

			if (currentPoint >= path.Length) {
				currentPoint = 0;
			}
	}

	void OnDrawGizmos (){
		if (path.Length > 0) {
			for (int i = 0; i < path.Length; i++) {
				Gizmos.DrawSphere (path [i].position,reachDist);
			}
		}
	}
}