using UnityEngine;
using System.Collections;

public class ActivePopup : MonoBehaviour {

	public GameObject aPopup;
	public bool oncepop;

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Player")
			aPopup.SetActive (true);
	}
	void OnCollisionExit2D(Collision2D col)
	{
		if (col.gameObject.tag == "Player") {
			aPopup.SetActive (false);
			if (oncepop == true)
				Destroy (aPopup);
		}
	}
}
