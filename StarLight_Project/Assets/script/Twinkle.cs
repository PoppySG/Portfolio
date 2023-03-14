using UnityEngine;
using System.Collections;

public class Twinkle : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine (Star ());
	}

	IEnumerator Star()
	{
		while (true) {
			SpriteRenderer renderer = GetComponent<SpriteRenderer> ();
			renderer.color = Color.Lerp(new Color(1f,1f,1f,0f),new Color(1f,1f,1f,1f),Mathf.PingPong(Time.time,1f));
			yield return null;
		}
	}
}
