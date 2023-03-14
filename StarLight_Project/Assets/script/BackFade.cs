using UnityEngine;
using System.Collections;

public class BackFade : MonoBehaviour {

	EpisodeName episode;
	Data data;

	public float fadeTime = 1f;
	public GameObject[] Obj;

	// Use this for initialization
	void Start () {
		episode = FindObjectOfType<EpisodeName> ();
		data = FindObjectOfType<Data> ();
	}
	
	// Update is called once per frame
	void Update () {

		if(GameObject.Find("Episode1"))
		if (episode.fade == true) {
			StartCoroutine (FadeOut ());
			Obj[0].SetActive (true);
			data.First = false;
		}
		if (GameObject.Find ("Episode2"))
		if (episode.fade == true) {
			StartCoroutine (FadeOut ());
			data.portalActive = true;
			data.Second = false;
		}
		if(GameObject.Find("Episode3"))
		if (episode.fade == true) {
			StartCoroutine (FadeOut ());
			data.portalActive = true;
			data.third = false;
		}

		if (Obj [0].activeSelf == true)
			Obj [1].SetActive (false);
	}

	IEnumerator FadeOut()
	{
		SpriteRenderer renderer = GetComponent<SpriteRenderer> ();

		renderer.color = Color.black;

		float rate = 1.0f / fadeTime;
		float progress = 0.0f;

		while (progress < 1.0f) {
			renderer.color = Color.Lerp (Color.black, Color.clear, progress);
			progress += rate * Time.deltaTime;

			yield return null;
		}
		renderer.color = Color.clear;
	}
}
