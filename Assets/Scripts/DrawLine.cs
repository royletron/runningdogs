using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DrawLine : DragAction 
{
	public LineObject currentLine;
	private Vector3 mousePos;

	void Awake()
	{
		isMousePressed = false;
	}
	private void ResetLine(Color col)
	{
		Debug.Log ("reset");
		currentLine.ResetLine (col);
	}
	private void LineToMouse()
	{
		Debug.Log ("Draw");
		mousePos = GetPointerPosition ();
		currentLine.LineToPoint (mousePos);
	}
	public override void Update ()
	{
		base.Update ();
		if (active) {
			GetComponent<SpriteRenderer> ().color = Color.red;
			if (justPressed) {
				ResetLine (Color.red);
			}
			// Drawing line when mouse is moving(presses)
			if (isMousePressed) {
				LineToMouse ();
			}
		}
	}

}