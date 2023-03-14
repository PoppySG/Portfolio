using UnityEngine;
using System.Collections;

public class Ladder : MonoBehaviour {

	public float speed = .5f;
	movement _movement;
	// Use this for initialization
	void Start () {
		_movement = FindObjectOfType<movement> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay2D(Collider2D col)
	{
		if (col.tag == "Player" && Input.GetKey (KeyCode.W)) {
			_movement.onladder = true;
			col.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, speed);
		
		} else if (col.tag == "Player" && Input.GetKey (KeyCode.S)) {
			_movement.onladder = true;
			col.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, -speed);
		
		} else {
			//_movement.onladder = false;
			col.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, .2f);
		}
	}
}
