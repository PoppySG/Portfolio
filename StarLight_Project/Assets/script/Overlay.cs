using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Overlay : MonoBehaviour {

	private static Potal instance;

	public Image overlay;

	public float fadeTime;

	void Awake()
	{
		//overlay.pixelInset = new Rect (0, 0, Screen.width, Screen.height);
		StartCoroutine (FadeToClear ());
	}
	void Update () {
		StartCoroutine (FadeToClear ());
	}

	public static Potal Instance
	{
		get
		{
			if (instance == null) {
				instance = GameObject.FindObjectOfType<Potal> ();
			}
			return instance;
		}
	}

	private IEnumerator FadeToClear()
	{
		overlay.gameObject.SetActive (true);
		overlay.color = Color.black;

		float rate = 1.0f / fadeTime;
		float progress = 0.0f;

		while (progress < 1.0f) {
			overlay.color = Color.Lerp (Color.black, Color.clear, progress);
			progress += rate * Time.deltaTime;

			yield return null;
		}
		overlay.color = Color.clear;
		overlay.gameObject.SetActive (false);
	}
}
