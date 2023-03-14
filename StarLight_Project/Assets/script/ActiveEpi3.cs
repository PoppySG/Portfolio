using UnityEngine;
using System.Collections;

public class ActiveEpi3 : MonoBehaviour {

	Data data;
	public GameObject[] Obj;

	// Use this for initialization
	void Start () {
		data = FindObjectOfType<Data> ();
		if (data.third == true) {
			Obj [0].SetActive (true);
			data.portalActive = false;
		}
	}
}
