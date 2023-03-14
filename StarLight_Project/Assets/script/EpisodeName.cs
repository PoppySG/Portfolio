using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EpisodeName : MonoBehaviour {

	public string[] fullText;
	private string currentText = "";
	public int textnum = 0;
	public float _waitTime = 0;
	public bool fade;
	public float fadeTime;

	public GameObject Obj;

	// Use this for initialization
	void Start () {
		fade = false;
		StartCoroutine (ShowText (_waitTime));
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator ShowText(float waitTime)
	{
		yield return new WaitForSeconds (waitTime);
		for (int i = 0; i <= fullText[textnum].Length; i++) {
			fullText [textnum] = fullText [textnum].Replace ("\\n", "\n");
			currentText = fullText [textnum].Substring (0, i);
			this.GetComponent<Text> ().text = currentText;
			yield return new WaitForSeconds (.1f);
		}
		yield return new WaitForSeconds (2f);
		{
			fade = true;
		}
		yield return null;
		Destroy (Obj);
	}
}
