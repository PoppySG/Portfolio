using UnityEngine;
using System.Collections;

public class DeleteCs : MonoBehaviour {
	
	public GameObject Obj;

	// Use this for initialization
	void Start () {
		if (Input.GetKeyDown (KeyCode.LeftShift))
			Destroy (Obj);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.LeftShift))
			Destroy (Obj);
	}
}
