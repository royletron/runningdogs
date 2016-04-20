using UnityEngine;
using System.Collections;

public class DragAction : MonoBehaviour
{
	public bool active = false;
	public bool isMousePressed = false;
	public bool justPressed = false;

	// Update is called once per frame
	public virtual void Update ()
	{
		if (active) {
			justPressed = false;
			if (Input.GetMouseButtonDown (0)) {
				isMousePressed = true;
				justPressed = true;
			} else if (Input.GetMouseButtonUp (0)) {
				Finished ();
			}
		}
	}

	public virtual void Finished() {
		isMousePressed = false;
		active = false;
		GetComponent<SpriteRenderer> ().color = Color.white;
	}

	public Vector3 GetPointerPosition()
	{
		Vector3 pos;
		if (Input.touchCount > 0) {
			pos = Camera.main.ScreenToWorldPoint (Input.touches [0].position);
		} else {
			pos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		}
		pos.z = 0;
		return pos;
	}
}

