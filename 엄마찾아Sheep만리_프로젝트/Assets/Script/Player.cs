using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float speed = 1f;
	public float jumpHeight;
	public bool is_jump;
	public GameObject over_Prefab;

	// Use this for initialization
	void Start () 
	{
		Time.timeScale = 1;
		over_Prefab.SetActive(false);
		is_jump = true;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (speed * Time.deltaTime, 0, 0);

		if(Input.GetKeyDown(KeyCode.Z))
			Jump();

		if (transform.position.y <= -3.5) {
			over_Prefab.SetActive(true);
			Invoke("TimeStop",2f);
		}
	}

	void Jump()
	{
			if(is_jump == true)
			{
				is_jump = false;
				GetComponent<Rigidbody2D> ().AddForce (Vector2.up * jumpHeight);
			}
	}

	void TimeStop()
	{
		Time.timeScale = 0;
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.name == "Map")
			is_jump = true;
	}
}
