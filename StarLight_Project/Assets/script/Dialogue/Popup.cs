using UnityEngine;
using System.Collections;

public class Popup : MonoBehaviour {

	public bool is_popup;
	public bool is_delete;

	public GameObject dialogue;
	public GameObject[] stop_script;

	//character _character;

	// Use this for initialization
	void Start () {
		//_character = GameObject.Find ("character").GetComponent<character> ();
		is_popup = false;
		is_delete = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (is_popup == true) {
			dialogue.SetActive (true);
			stop_script [0].GetComponent<movement> ().enabled = false;
			stop_script [0].GetComponent<imageChange> ().enabled = false;
			stop_script [1].GetComponent<character> ().enabled = false;
			stop_script [2].GetComponent<character2> ().enabled = false;
		}
		if (is_popup == false) {
			dialogue.SetActive (false);
			stop_script [0].GetComponent<movement> ().enabled = true;
			stop_script [0].GetComponent<imageChange> ().enabled = true;
			stop_script [1].GetComponent<character> ().enabled = true;
			stop_script [2].GetComponent<character2> ().enabled = true;

		}
		if (is_delete == true) {
			dialogue.SetActive (false);
			stop_script [0].GetComponent<movement> ().enabled = true;
			stop_script [0].GetComponent<imageChange> ().enabled = true;
			stop_script [1].GetComponent<character> ().enabled = true;
			stop_script [2].GetComponent<character2> ().enabled = true;
			Destroy (this.gameObject);
			is_delete = false;
		}
	}


	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Player")
			//_character.anim.SetFloat ("PWalk", 0);
			is_popup = true;
	}
	void OnCollisionExit2D(Collision2D col)
	{
		if (col.gameObject.tag == "Player")
			is_popup = false;
	}
}
