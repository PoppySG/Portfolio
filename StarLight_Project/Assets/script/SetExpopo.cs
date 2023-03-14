using UnityEngine;
using System.Collections;

public class SetExpopo : MonoBehaviour {

	public GameObject[] Obj;
	Data data;

	// Use this for initialization
	void Start () {
		data = FindObjectOfType<Data> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (data.TalkPB == true) {
			Obj [0].SetActive (false);
			Obj [1].SetActive (true);
			//Obj [2].SetActive (false);
		}
		if(data.seefire == true)
		{
			data.TalkPB = false;
			Obj [0].SetActive (false);
			Obj [1].SetActive (false);
		}
	}
}
