using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour {

	public bool onLoad;
	Data data;

	// Use this for initialization
	void Start () {
		onLoad = false;
		data = FindObjectOfType<Data> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Alpha0))
			SceneManager.LoadScene ("Stage2");
	}

	void OnMouseDown()
	{
		if (name == "Start") {
			onLoad = false;
			PlayerPrefs.SetString ("load", onLoad.ToString ());
			SceneManager.LoadScene ("Stage1");
		}
		if (name == "Load") {
			onLoad = true;
			PlayerPrefs.SetString ("load", onLoad.ToString ());
			SceneManager.LoadScene (data.currentScene);
		}
		if (name == "Exit")
			Application.Quit ();
	}
}
