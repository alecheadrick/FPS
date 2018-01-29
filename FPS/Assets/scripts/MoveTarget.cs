using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTarget : MonoBehaviour {
    [SerializeField]
    Transform[] wayPoints;
    int currentWayPoint = 0;
    Rigidbody rb;
    [SerializeField]
    float moveSpeed = 5;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();	
	}
	
	// Update is called once per frame
	void Update () {
        Movement();
	}
    void Movement() {
        if (Vector3.Distance(transform.position, wayPoints[currentWayPoint].position) < .25f) {
            currentWayPoint += 1;
            currentWayPoint = currentWayPoint % wayPoints.Length;
        }
        Vector3 _dir = (wayPoints[currentWayPoint].position - transform.position).normalized;
        rb.MovePosition(transform.position + _dir * moveSpeed * Time.deltaTime);
    }
}
