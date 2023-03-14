using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Intro : MonoBehaviour {

	public GameObject Intro_Prefab;

	// Use this for initialization
	void Start () 
	{
		Screen.SetResolution(512, 768, false); 
		Invoke ("Develop", 0);
		Invoke ("NextScene", 4);
	} 

	void Develop()
	{
		Instantiate (Intro_Prefab, new Vector3 (0, 1, 0), Quaternion.identity);
	}

	void NextScene()
	{
		Application.LoadLevel("Title");
	}

}
