using UnityEngine;
using System.Collections;

public class character : MonoBehaviour {

	public Animator anim;
	public float state_time = 0;
	public bool is_jump;

	movement _movement;


	// Use this for initialization
	void Start () {
		_movement = GameObject.Find ("CharacterManager").GetComponent<movement> ();
		is_jump = true;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKey (KeyCode.A)) {
			state_time = 0;
			anim.ResetTrigger ("PIdle");
			anim.ResetTrigger ("PIdleL");
			if (_movement.is_jump == true)
				anim.SetFloat ("PWalk", -0.1f);
			anim.ResetTrigger ("PRight");
			anim.SetTrigger ("PLeft");
		}

		if (Input.GetKey (KeyCode.D)) {
			state_time = 0;
			anim.ResetTrigger ("PIdle");
			anim.ResetTrigger ("PIdleL");
			if (_movement.is_jump == true)
				anim.SetFloat ("PWalk", 5.0f);
			anim.ResetTrigger ("PLeft");
			anim.SetTrigger ("PRight");
		}

		if (Input.GetKeyUp (KeyCode.D) || Input.GetKeyUp(KeyCode.A)) {
			anim.SetFloat ("PWalk", 0);
		}

		if (_movement.onladder == true) {
			anim.ResetTrigger ("Idle");
			if (Input.GetKey (KeyCode.W)) {
				//myrigidbody2D.gravityScale = 0;
				anim.ResetTrigger ("PLadderI");
				anim.SetTrigger ("PLadder");
			}
			if (Input.GetKey (KeyCode.S)) {
				//myrigidbody2D.gravityScale = 0;
				anim.ResetTrigger ("PLadderI");
				anim.SetTrigger ("PLadder");
			}
			if (_movement.onClimb == false) {
				anim.ResetTrigger ("PLadder");
				anim.SetTrigger ("PLadderI");
			}
		}

		if (_movement.onladder == false) {
			//myrigidbody2D.gravityScale = 1f;
			anim.ResetTrigger("PLadder");
			anim.ResetTrigger ("PLadderI");
			anim.SetTrigger ("Idle");
		}
		if (Input.GetKey (KeyCode.Space)) {
			Jump ();
			state_time = 0;
		} 

		else {
			state_time += Time.deltaTime;
			if (state_time > 3) {
				if (_movement.c_right == true)
					anim.SetTrigger ("PIdle");
				if (_movement.c_right == false)
					anim.SetTrigger ("PIdleL");
				if (state_time > 4.5f)
					state_time = 0;
			} else {
				anim.ResetTrigger ("PIdle");
				anim.ResetTrigger ("PIdleL");
			}
		}

		if (_movement.is_hit == true) {
			StartCoroutine (BlinkCharacter ());
			_movement.is_hit = false;
		}
	}

	void Jump()
	{
		if (is_jump == true) {
			GetComponent<Rigidbody2D> ().AddForce (Vector2.up * 63);
			if (_movement.c_right == true)
				anim.SetTrigger ("PJump");
			if (_movement.c_right == false)
				anim.SetTrigger ("PJumpL");
			is_jump = false;
		}
		else {
			anim.ResetTrigger ("PJump");
			anim.ResetTrigger ("PJumpL");
		}
	}

	IEnumerator BlinkCharacter()
	{
		int blinkcount = 0;
		while (blinkcount <= 3) {
			this.GetComponent<SpriteRenderer> ().enabled = false;
			yield return new WaitForSeconds (.2f);
			this.GetComponent<SpriteRenderer> ().enabled = true;
			yield return new WaitForSeconds (.2f);
			blinkcount++;
		}
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "ground") {
			is_jump = true;
		}

	}
	void OnCollisionStay2D(Collision2D col)
	{
		if (col.gameObject.tag == "pop") {
			anim.SetFloat ("PWalk", 0);
		}
	}
}
