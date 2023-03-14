using UnityEngine;
using System.Collections;

public class EBullet : MonoBehaviour {
	public float speed;
	private Vector2 dir;

	movement _movement;

	public GameObject player;

	// Use this for initialization
	void Start () {
		Destroy (this.gameObject, 2f);
		player = GameObject.FindGameObjectWithTag ("Player");

		dir = (player.transform.position- this.transform.position);
		_movement = GameObject.Find("CharacterManager").GetComponent<movement> ();
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (dir.normalized * speed * Time.deltaTime);
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Player") {
			Destroy (this.gameObject);
			_movement.hpbar.value--;
			_movement.is_hit = true;
		}
	}
}
