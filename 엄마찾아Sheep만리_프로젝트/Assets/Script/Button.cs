using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {
	[SerializeField]
	private Sprite[] buttonImage;
	[SerializeField]
	private string changeScene;
	[SerializeField]
	private GameObject sheep;
	public AudioSource sound;


	void OnMouseEnter()
	{
		if (name == "StartButton")
			sound.Play ();
		
		if (name == "ExitButton")
			sound.Play ();
	}

	void OnMouseDown()
	{
		if (name == "StartButton")
			GetComponent<SpriteRenderer> ().sprite = buttonImage[1];

		if (name == "ExitButton")
			GetComponent<SpriteRenderer> ().sprite = buttonImage[1];
	}

	void OnMouseUp()
	{
		if (name == "StartButton") 
		{
			GetComponent<SpriteRenderer> ().sprite = buttonImage [0];
			Instantiate (sheep, new Vector3 (6.7f, 0.2f, 0), Quaternion.identity);
			//if(sheep.transform.position.x <= -1.0f)
			//	Application.LoadLevel(changeScene);
		}
		if (name == "ExitButton") 
		{
			GetComponent<SpriteRenderer> ().sprite = buttonImage [0];
			Application.Quit();
		}
	}
}
