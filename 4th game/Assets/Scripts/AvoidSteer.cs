using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvoidSteer : MonoBehaviour {

	public float speed;
	public GameObject target;
	public GameObject dog;
	public static float minDist;

	private bool tagged;
	private Rigidbody body;

	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		Vector3 desired = target.transform.position - transform.position;

		if (desired.magnitude < minDist) {
			print("avoiding wolf");
			float actual = desired.magnitude - minDist;
			body.AddForce(desired.normalized *
				actual * speed - body.velocity);
		}

	}

	void OnCollisionEnter(Collision coll) {
		if (!tagged && coll.gameObject == target) {
			print("WOLF!");
			dog.GetComponent<FollowSteer>().IncreaseSpeed();
			minDist += 2;
			tagged = true;
		}
	}
}
