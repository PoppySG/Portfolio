using UnityEngine;
using System.Collections;

public class bullet : MonoBehaviour {
	public float speed;
	private Vector2 dir;


	// Use this for initialization
	void Start () {
		Destroy (this.gameObject, 1f);
		dir = (Camera.main.ScreenToWorldPoint (Input.mousePosition) - this.transform.position);
	}
	
	// Update is called once per frame
	void Update () {

			transform.Translate (dir.normalized * speed * Time.deltaTime);
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Enemy") {
			Destroy (this.gameObject);
		}
	}
}
