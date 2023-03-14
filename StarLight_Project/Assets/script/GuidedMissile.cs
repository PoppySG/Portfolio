using UnityEngine;
using System.Collections;

public class GuidedMissile : MonoBehaviour {

	public float speed = 5;
	public float rotatingSpeed = 200;
	public GameObject target;
	public float count;
	float hitcount = 0;

	movement _movement;


	Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		target = GameObject.FindGameObjectWithTag ("Player");

		rb = GetComponent<Rigidbody2D> ();
		_movement = GameObject.Find("CharacterManager").GetComponent<movement> ();
	}

	// Update is called once per frame
	void FixedUpdate () {

		count += Time.deltaTime;
		if (count >= 6f)
			Destroy (this.gameObject);
		
		Vector2 point2Target = (Vector2)transform.position - (Vector2)target.transform.position;
		point2Target.Normalize ();
		float value = Vector3.Cross (point2Target, transform.right).z;

		if (value > 0) {
			rb.angularVelocity = rotatingSpeed;
		} else if (value < 0)
			rb.angularVelocity = -rotatingSpeed;
		else
			rotatingSpeed = 0;

		rb.velocity = transform.right * speed;
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Player") {
			Destroy (this.gameObject);
			_movement.hpbar.value--;
			_movement.is_hit = true;
		}

		if (col.gameObject.tag == "bullet") {
			hitcount++;
			if (hitcount == 2)
				Destroy (this.gameObject);
		}
	}
}
