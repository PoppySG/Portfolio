using UnityEngine;
using System.Collections;

public class PristMove : MonoBehaviour {

	public float pos;
	public float count;
	public bool poschange;

	public Animator anim;

	public GameObject prist;

	//Popup popup;

	// Use this for initialization
	void Start () {
		//popup = FindObjectOfType<Popup> ();
		pos = Random.Range (-1, 2);
	}
	
	// Update is called once per frame
	void Update () {
		count += Time.deltaTime;

		if (count < 1f) {
			transform.Translate (pos * Time.deltaTime, 0, 0);
		}
		if (count > 1f) {
			poschange = true;
			count = 0;
		}
		if (poschange == true) {
			pos = Random.Range (-1, 2);
			poschange = false;
		}

		if (pos == -1) {
			anim.SetFloat ("PWalk", -5.0f);
			anim.ResetTrigger ("PRight");
			anim.SetTrigger ("PLeft");
		}
		if (pos == 0) {
			anim.SetFloat ("PWalk", 0f);
		}
		if (pos == 1) {
			anim.SetFloat ("PWalk", 5.0f);
			anim.ResetTrigger ("PLeft");
			anim.SetTrigger ("PRight");
		}

		/*if (popup.is_popup == false)
			prist.GetComponent<PristMove> ().enabled = true;*/
	}

	void OnCollisionStay2D(Collision2D col)
	{
		if (col.gameObject.name == "PWall1") {
			if (pos == -1)
				pos = Random.Range (0, 2);
		}
		if (col.gameObject.name == "PWall2")
		{
			if (pos == 1)
				pos = Random.Range (-1, 1);
		}
		if (col.gameObject.tag == "Player") {
			if (Input.GetKeyDown (KeyCode.LeftShift)) {
				prist.GetComponent<PristMove> ().enabled = false;
			}
		}
	}
	void OnCollisionExit2D(Collision2D col)
	{
		if (col.gameObject.tag == "Player") {
			prist.GetComponent<PristMove> ().enabled = true;
		}
	}
}
