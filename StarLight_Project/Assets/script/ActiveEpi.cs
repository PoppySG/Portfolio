using UnityEngine;
using System.Collections;

public class ActiveEpi : MonoBehaviour {

	Data data;
	public GameObject[] Obj;

	// Use this for initialization
	void Start () {
		data = FindObjectOfType<Data> ();
		if (data.First == true) {
			Obj [0].SetActive (true);
			Obj [1].SetActive (false);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
