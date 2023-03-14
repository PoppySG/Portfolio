using UnityEngine;
using System.Collections;

public class SetPortal : MonoBehaviour {

	public GameObject Obj;
	Data data;

	// Use this for initialization
	void Start () {
		data = FindObjectOfType<Data> ();

		if (Obj.activeSelf == true) {
			if (Input.GetKeyDown (KeyCode.LeftShift)) {
				data.portalActive = false;
				data.wayActive = false;
			}
		}

	}
	
	// Update is called once per frame
	void Update () {
		if (Obj.activeSelf == true) {
			if (Input.GetKeyDown (KeyCode.LeftShift)) {
				data.portalActive = false;
				data.wayActive = false;
			}
		}
	}
}
