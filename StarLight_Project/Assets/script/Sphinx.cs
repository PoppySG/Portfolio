using UnityEngine;
using System.Collections;

public class Sphinx : MonoBehaviour {

	public Animator anim;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Player") {
			anim.ResetTrigger ("Down");
			anim.SetTrigger ("Up");
		}
	}

	void OnCollisionExit2D(Collision2D col)
	{
		if (col.gameObject.tag == "Player") {
			anim.ResetTrigger ("Up");
			anim.SetTrigger ("Down");
		}
	}
}
