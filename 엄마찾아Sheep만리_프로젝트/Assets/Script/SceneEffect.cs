using UnityEngine;
using System.Collections;

public class SceneEffect : MonoBehaviour {
	public string changeScene;

	void Start()
	{
		DontDestroyOnLoad (gameObject);
	}

	// Update is called once per frame
	void Update () 
	{
		gameObject.transform.Translate (-4.0f * Time.deltaTime, 0, 0);
		if (transform.position.x <= -1.0f)
			Application.LoadLevel (changeScene);
		if (transform.position.x <= -7.0f)
			Destroy (gameObject);
	}


}
