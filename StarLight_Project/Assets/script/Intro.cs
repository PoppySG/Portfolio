using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		Invoke ("NextScene", 1);
	} 

	void NextScene()
	{
		SceneManager.LoadScene ("Title");
	}

}
