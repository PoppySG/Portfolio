using UnityEngine;
using System.Collections;

public class player : MonoBehaviour 
{
	public float quat;
	public bool is_flip;
	public bool trun;
	public float _pos;

	void start()
	{
		DontDestroyOnLoad (this.gameObject);

		is_flip = false;
		trun = false;
	}

	void Update()
	{
		Vector3 mouse_pos = Input.mousePosition;
		Vector3 player_pos = Camera.main.WorldToScreenPoint(this.transform.position);

		mouse_pos.x = mouse_pos.x - player_pos.x;
		mouse_pos.y = mouse_pos.y - player_pos.y;

		float angle = Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;
		this.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + quat));
	

		if (90 < angle || -90 > angle) {
			if (is_flip == false) {
				trun = true;
				Flip ();
				is_flip = true;
				quat = -quat;
				transform.localPosition = transform.localPosition + new Vector3 (_pos, 0,0);
			}
		}
		if (-90 <= angle && 90 >= angle) {
			if (is_flip == true) {
				trun = true;
				Flip ();
				is_flip = false;
				quat = -quat;
				transform.localPosition = transform.localPosition + new Vector3 (-_pos, 0,0);

			}
		}
	}

	void Flip()
	{
		if (trun == true) {
			// Multiply the player's x local scale by -1
			Vector3 theScale = transform.localScale;
			theScale.y *= -1;
			transform.localScale = theScale;
			trun = false;
		}
	}
}