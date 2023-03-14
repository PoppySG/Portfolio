using UnityEngine;
using System.Collections;

public class TalkNPCs : MonoBehaviour {

	public GameObject _npc;
	public GameObject pop;

	void OnCollisionStay2D(Collision2D col)
	{
		if (col.gameObject.tag == "Player") {
			if (Input.GetKeyDown (KeyCode.LeftShift)) {
				pop.SetActive (true);
			}
		}
	}
	void OnCollisionExit2D(Collision2D col)
	{
		if(col.gameObject.tag == "Player")
			pop.SetActive (false);
	}
}
