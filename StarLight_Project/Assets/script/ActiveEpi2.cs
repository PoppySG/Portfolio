using UnityEngine;
using System.Collections;

public class ActiveEpi2 : MonoBehaviour {

	Data data;
	public GameObject[] Obj;

	// Use this for initialization
	void Start () {
		data = FindObjectOfType<Data> ();
		if (data.Second == true) {
			Obj [0].SetActive (true);
			Obj [1].SetActive (false);
		}
	}
}
