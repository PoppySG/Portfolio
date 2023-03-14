using UnityEngine;
using System.Collections;

public class AfterFirework : MonoBehaviour {

	public GameObject[] Obj;
	Data data;

	// Use this for initialization
	void Start () {
		data = FindObjectOfType<Data> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (data.seefire == true) {
			Obj [0].SetActive (true);
			Obj [1].SetActive (true);
		}
	}
}
