using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderSteer : MonoBehaviour
{
	public float speed;
	public float angle;

	private Rigidbody body;

	// Use this for initialization
	void Start()
	{
		body = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		body.AddForce(transform.forward * speed);
		transform.Rotate(Vector3.back * (Random.value * 2 * angle - angle));
	}
}
