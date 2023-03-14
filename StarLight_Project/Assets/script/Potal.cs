using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Potal : MonoBehaviour {

	private static Potal instance;

	public Image overlay;

	public float fadeTime;

	public string sceneName;
	public int potalnum;
	public bool is_potal = false;

	PortalData PD;


	void Start()
	{
		PD = FindObjectOfType<PortalData> ();
	}

	void Awake()
	{
		//overlay.rectTransform = new Rect (0, 0, Screen.width, Screen.height);
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

	void OnCollisionStay2D(Collision2D col)
	{
		if (col.gameObject.tag == "Player") {
			if (Input.GetKey (KeyCode.W)) {
				SceneManager.LoadScene (sceneName);
				is_potal = true;
				PD.getPotal = true;
				PlayerPrefs.SetString ("potal", is_potal.ToString ());
				PD.portalnum [potalnum] = true;

			}
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
