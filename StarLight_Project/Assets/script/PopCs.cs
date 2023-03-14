using UnityEngine;
using System.Collections;

public class PopCs : MonoBehaviour {

	public GameObject[] Obj;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Obj [0].activeSelf == true)
			Obj [1].SetActive (true);
	}
}
