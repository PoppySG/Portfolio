using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Dialog : MonoBehaviour {

	[SerializeField]
	private float delay = 0.2f;

	public string[] fullText;
	private string currentText = "";
	public int textnum;

	NPC npc;

	// Use this for initialization
	void Start () {
		StartCoroutine (ShowText ());
		textnum = 0;
		npc = FindObjectOfType<NPC> ();
	}

	void Update()
	{
		if (Input.GetKeyDown (KeyCode.LeftShift)) {
			textnum += 1;
			StartCoroutine (ShowText ());
			if (fullText.Length <= textnum) {
				//textnum = 0;
				npc.is_check = false;
			}
		}
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			textnum += 1;
			StartCoroutine (ShowText ());
		}
		if (Input.GetKeyDown (KeyCode.Alpha2)) {
			textnum += 2;
			StartCoroutine (ShowText ());
		}
	}

	IEnumerator ShowText()
	{
		for (int i = 0; i <= fullText[textnum].Length; i++) {
			currentText = fullText [textnum].Substring (0, i);
			this.GetComponent<Text> ().text = currentText;
			yield return new WaitForSeconds (delay);
		}
	}
}