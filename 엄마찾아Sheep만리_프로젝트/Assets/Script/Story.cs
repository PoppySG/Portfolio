using UnityEngine;
using System.Collections;

public class Story : MonoBehaviour {

	public GameObject[] story_Prefab;
	public int count = 0;
	public string changeScene;

	// Use this for initialization
	void Start () 
	{

		story_Prefab [0].SetActive (true);
		story_Prefab [1].SetActive (false);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.Space))
			count++;
		if (count == 1) 
		{
			story_Prefab [0].SetActive (false);
			story_Prefab [1].SetActive (true);
		}
		else if (count == 2)
			Application.LoadLevel(changeScene);
	}
}
