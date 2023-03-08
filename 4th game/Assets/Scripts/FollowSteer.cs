using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowSteer : MonoBehaviour {

	public GameObject target;
	public float speed;
	public float rotationSpeed;

	private Rigidbody body;

    void Awake()
    {
        StartCoroutine(SwanSpeed());
    }

    void Start () {
		body = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 desired = (target.transform.position - transform.position).normalized;
		body.AddForce(desired * speed - body.velocity);

		float angle = (Mathf.Atan2(desired.y, desired.x) * Mathf.Rad2Deg) - 90;
		Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
		transform.rotation = Quaternion.Slerp(transform.rotation,
			q, Time.deltaTime * rotationSpeed);

	}

	public void IncreaseSpeed() {
		speed *= 1.2f;
	}

	void OnCollisionEnter(Collision coll) {
		if (coll.gameObject == target) {
            SceneManager.LoadScene("Death_scene");
            GetComponent<AudioSource>().Play();
		}
	}


    IEnumerator SwanSpeed()
    {
        while (true)
        {
            yield return new WaitForSeconds(3);
            IncreaseSpeed();
			// After 60 seconds, the swan speed will be 10+.
			// This basically makes the game unplayable. So the player has one minute to make it to the cave
        }
    }

}
