using UnityEngine;
using System.Collections;

public class Route : MonoBehaviour {

	public GameObject[] Obj;
	Data data;
	DialogueManager dm;

	// Use this for initialization
	void Start () {
		data = FindObjectOfType<Data> ();
		dm = FindObjectOfType<DialogueManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (data.route == "A")
			dm.nDialogue = Obj [0];
		if (data.route == "B")
			dm.nDialogue = Obj [1];
	}
}
