using UnityEngine;
using System.Collections;

public class rotate : MonoBehaviour {

	public bool is_flip;
	public bool turn;

	// Use this for initialization
	void Start () {
		is_flip = false;
		turn = false;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 mouse_pos = Input.mousePosition;
		Vector3 player_pos = Camera.main.WorldToScreenPoint(this.transform.position);

		mouse_pos.x = mouse_pos.x - player_pos.x;
		mouse_pos.y = mouse_pos.y - player_pos.y;

		float angle = Mathf.Atan2 (mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;

		if (90 < angle || -90 > angle) {
			if (is_flip == false) {
				turn = true;
				Flip ();
				is_flip = true;
			}
		}
		if (-90 <= angle && 90 >= angle) {
			if (is_flip == true) {
				turn = true;
				Flip ();
				is_flip = false;
			}
		}
	}

	void Flip()
	{
		if (turn == true) {
			// Multiply the player's x local scale by -1
			Vector3 theScale = transform.localScale;
			theScale.x *= -1;
			transform.localScale = theScale;
			turn = false;
		}
	}
}
