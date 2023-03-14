using UnityEngine;
using System.Collections;

public class WindowChange : MonoBehaviour {

	public GameObject Obj;
	Data data;

	// Use this for initialization
	void Start () {
		data = FindObjectOfType<Data> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (data.fireWork == true)
			Obj.SetActive (false);
	}
}
