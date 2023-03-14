using UnityEngine;
using System.Collections;

public class DropBullet : MonoBehaviour {

	public float speed;
	movement _movement;

	// Use this for initialization
	void Start () {
		_movement = GameObject.Find("CharacterManager").GetComponent<movement> ();
	}

	// Update is called once per frame
	void Update () {
		transform.Translate (0, -speed * Time.deltaTime, 0);
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.gameObject.name == "ground")
			Destroy (this.gameObject);
		
		if (col.gameObject.tag == "Player") {
			Destroy (this.gameObject);
			_movement.hpbar.value--;
			_movement.is_hit = true;
		}
	}
}
