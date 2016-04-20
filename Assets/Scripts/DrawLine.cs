﻿using UnityEngine;
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
	private void ResetLine()
	{
		currentLine.ResetLine ();
	}
	private void LineToMouse()
	{
		mousePos = GetPointerPosition ();
		currentLine.LineToPoint (mousePos);
	}
	public override void Finished ()
	{
		base.Finished ();
		if (currentLine.checkCollide) {
			PlayerController currentPlayer = GetComponent<PlayerController> ();
			foreach (PlayerController player in PlayControl.players) {
				if (player != currentPlayer) {
					if (player.side == currentPlayer.side) {
						Debug.Log (player.runLine.isLineCollide (currentPlayer.throwLine.pointsList [0], currentPlayer.throwLine.pointsList [1]));
					}
				}
			}
		}
	}
	public override void Update ()
	{
		base.Update ();
		if (active) {
			GetComponent<SpriteRenderer> ().color = Color.red;
			if (justPressed) {
				ResetLine ();
			}
			// Drawing line when mouse is moving(presses)
			if (isMousePressed) {
				LineToMouse ();
			}
		}
	}



}