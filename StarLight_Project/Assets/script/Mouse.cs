using UnityEngine;
using System.Collections;

public class Mouse : MonoBehaviour {

	public Texture2D cursorTexture;
	public CursorMode cursormode = CursorMode.Auto;
	public Vector2 hotSpot = Vector2.zero;

	// Use this for initialization
	void Start () {

		hotSpot.x = cursorTexture.width / 2;
		hotSpot.y = cursorTexture.height / 2;
		Cursor.SetCursor (cursorTexture, hotSpot, cursormode);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
