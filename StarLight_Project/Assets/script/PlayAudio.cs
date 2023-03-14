using UnityEngine;
using System.Collections;

public class PlayAudio : MonoBehaviour {

	public AudioSource sound;

	// Use this for initialization
	void Start () {
		sound.Play ();
	}
}
