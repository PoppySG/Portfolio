using UnityEngine;
using System.Collections;

public class FinishExpopo : MonoBehaviour {

	public GameObject Obj;
	Data data;

	// Use this for initialization
	void Start () {
		data = FindObjectOfType<Data> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Obj.activeSelf == true)
			data.third = true;
	}
}
