using UnityEngine;
using System.Collections;

public class Star : MonoBehaviour {

	public float drop;
	public float count;

	movement _movement;

	// Use this for initialization
	void Start () {
		drop = Random.Range (-1f, 1f);
		_movement = FindObjectOfType<movement> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		count += Time.deltaTime;

		if(count < 0.3f)
			transform.Translate (drop * Time.deltaTime, 0, 0);
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Player") {
			Destroy (this.gameObject);
			_movement.playerHP++;
			_movement.hpbar.value++;
		}
	}
}
