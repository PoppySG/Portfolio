using UnityEngine;
using System.Collections;

public class TitleCh : MonoBehaviour {

	public float state_time = 0;

	public Animator anim;

	public bool c_right;

	// Use this for initialization
	void Start () {
		c_right = true;
	}
	
	// Update is called once per frame
	void Update () {
		state_time += Time.deltaTime;
		if (state_time > 3) {
			if (c_right == true)
				anim.SetTrigger ("CIdle");
			if (c_right == false)
				anim.SetTrigger ("CIdleL");
			if (state_time > 4.5f)
				state_time = 0;
		} else {
			anim.ResetTrigger ("CIdle");
			anim.ResetTrigger ("CIdleL");
		}
	}
}