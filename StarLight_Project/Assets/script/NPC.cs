using UnityEngine;
using System.Collections;

public class NPC : MonoBehaviour {

	public bool is_check;
	public GameObject[] dialog;

	// Use this for initialization
	void Start () {
		is_check = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (is_check == true) {
			dialog [0].SetActive (true);
			dialog [1].GetComponent<movement> ().enabled = false;
			dialog [1].GetComponent<imageChange> ().enabled = false;
			dialog [2].GetComponent<character> ().enabled = false;
			dialog [3].GetComponent<character2> ().enabled = false;
		}
		if (is_check == false) {
			dialog [0].SetActive (false);
			dialog [1].GetComponent<movement> ().enabled = true;
			dialog [1].GetComponent<imageChange> ().enabled = true;
			dialog [2].GetComponent<character> ().enabled = true;
			dialog [3].GetComponent<character2> ().enabled = true;
		}
	}
}
