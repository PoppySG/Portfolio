using UnityEngine;
using System.Collections;

public class Tutorial2 : MonoBehaviour {

	public GameObject jump;

	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.Z))
			jump.SetActive (false);
	}
}
