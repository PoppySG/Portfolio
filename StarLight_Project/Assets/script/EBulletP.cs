using UnityEngine;
using System.Collections;

public class EBulletP : MonoBehaviour {
	public float speed;
	private Vector2 dir;

	public GameObject player;

	// Use this for initialization
	void Start () {
		Destroy (this.gameObject, 1f);
		player = GameObject.Find("PattyCring");

		dir = (player.transform.position- this.transform.position);
	}

	// Update is called once per frame
	void Update () {
		transform.Translate (dir.normalized * speed * Time.deltaTime);
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.name == "PattyCring") {
			Destroy (this.gameObject);
		}
	}
}
