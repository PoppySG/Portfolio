using UnityEngine;
using System.Collections;

public class Check : MonoBehaviour {

	public GameObject dialogue;
	public GameObject[] nDialogue;
	public float pos;
	public float maxpos;

	//DialogueManager dm;


	// Use this for initialization
	void Start () {
		//dm = FindObjectOfType<DialogueManager> ();
		dialogue.GetComponent<DialogueManager> ().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
			

		if (this.transform.position.y <= 0.34f || this.transform.position.y >= maxpos)
		{
		}
		if (Input.GetKeyDown (KeyCode.S)) {
			//transform.Translate (0, -pos, 0);
			if(this.transform.localPosition.y >= maxpos+0.03f)
				transform.Translate (0, -pos, 0);
		}
		if (Input.GetKeyDown (KeyCode.W)) {
			//transform.Translate (0, pos, 0);
			if(this.transform.localPosition.y <= 0.34f)
				transform.Translate (0, pos, 0);
		}
	}

	void OnTriggerStay2D(Collider2D col)
	{
		if (col.name == "Check1") {
			if (Input.GetKeyDown (KeyCode.LeftShift)) {
				dialogue.GetComponent<DialogueManager> ().enabled = true;
				//dm.check1 = true;
				//dm.is_Q = false;
				//nDialogue [0].SetActive (false);
				nDialogue [0].SetActive (true);
			}
		}
		if (col.name == "Check2") {
			if (Input.GetKeyDown (KeyCode.LeftShift)) {
				dialogue.GetComponent<DialogueManager> ().enabled = true;
				//dm.check2 = true;
				//dm.is_Q = false;
				//nDialogue [0].SetActive (false);
				nDialogue [1].SetActive (true);
			}
		}
		if (col.name == "Check3") {
			if (Input.GetKeyDown (KeyCode.LeftShift)) {
				dialogue.GetComponent<DialogueManager> ().enabled = true;
				//dm.check2 = true;
				//dm.is_Q = false;
				//nDialogue [0].SetActive (false);
				nDialogue [2].SetActive (true);
			}
		}
	}
}
