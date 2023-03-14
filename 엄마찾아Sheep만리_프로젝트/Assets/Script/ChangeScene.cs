using UnityEngine;
using System.Collections;

public class ChangeScene : MonoBehaviour {

	public string changeScene;


	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.Space)) 
			Application.LoadLevel (changeScene);
	}
}
