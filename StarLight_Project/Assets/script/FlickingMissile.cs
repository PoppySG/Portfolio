using UnityEngine;
using System.Collections;

public class FlickingMissile : MonoBehaviour {

	public Rigidbody2D rb;
	public float ballForce;
	movement _movement;

	public int count;

	// Use this for initialization
	void Start () {
		rb.AddForce (new Vector2 (ballForce, ballForce));
		_movement = GameObject.Find("CharacterManager").GetComponent<movement> ();
		count = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (count >= 5)
			Destroy (this.gameObject);
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Player") {
			Destroy (this.gameObject);
			_movement.hpbar.value--;
			_movement.is_hit = true;
		}

		if (col.gameObject.tag == "Flick") {
			count++;
		}
	}
}
