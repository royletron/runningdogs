using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MovePlayer : DragAction {
	private Vector3 previous;
	public override void Update ()
	{
		base.Update ();
		if (active) {
			GetComponent<SpriteRenderer> ().color = Color.blue;
			if (justPressed) {
				previous = this.transform.position;
			}
			if (isMousePressed) {
				MoveToMouse ();
			}
		}
	}
	void MoveToMouse () {
		this.transform.position = GetPointerPosition ();
		LineRenderer line = GetComponentInParent<LineRenderer> ();
		DrawLine draw = GetComponentInParent<DrawLine> ();
		List<Vector3> tmp = new List<Vector3>();
		if (draw.pointsList.Count > 0) {
			for(int i=0; i<draw.pointsList.Count; i++) {
				Vector3 pos = new Vector3 (draw.pointsList [i].x + (this.transform.position.x - previous.x), draw.pointsList [i].y + (this.transform.position.y - previous.y), 0);
				tmp.Add(pos);
				line.SetPosition (i, pos);
			}
			previous = this.transform.position;
			draw.pointsList = tmp;
		}
	}
}
