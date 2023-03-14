using UnityEngine;
using System.Collections;

public class Turn : MonoBehaviour {

	public float speed = 1;


	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.Space)) 
		{
			Vector3 rot = transform.rotation.eulerAngles;
			rot.z += 90;
			transform.rotation = Quaternion.Euler (rot.x, rot.y, rot.z);
		}
	}
}
