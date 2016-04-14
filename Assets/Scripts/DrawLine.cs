using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DrawLine : DragAction 
{
	private LineRenderer line;
	public List<Vector3> pointsList;
	private Vector3 mousePos;

	struct myLine
	{
		public Vector3 StartPoint;
		public Vector3 EndPoint;
	};
	void Awake()
	{
		// Create line renderer component and set its property
		line = gameObject.AddComponent<LineRenderer>();
		line.material =  new Material(Shader.Find("Particles/Additive"));
		line.SetVertexCount(0);
		line.SetWidth(0.1f,0.1f);
		line.SetColors(Color.red, Color.red);
		line.useWorldSpace = true;	
		isMousePressed = false;
		pointsList = new List<Vector3>();
	}
	private void ResetLine(Color col)
	{
		line.SetVertexCount (0);
		pointsList.RemoveRange(0,pointsList.Count);
		line.SetColors (col, col);
	}
	private void LineToMouse()
	{
		mousePos = GetPointerPosition ();
		if (!pointsList.Contains (mousePos)) 
		{
			pointsList.Add (mousePos);
			line.SetVertexCount (pointsList.Count);
			line.SetPosition (pointsList.Count - 1, (Vector3)pointsList [pointsList.Count - 1]);
		}
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

	//	-----------------------------------	
	//	Following method checks whether given two points are same or not
	//	-----------------------------------	
	private bool checkPoints (Vector3 pointA, Vector3 pointB)
	{
		return (pointA.x == pointB.x && pointA.y == pointB.y);
	}
	//	-----------------------------------	
	//	Following method checks whether given two line intersect or not
	//	-----------------------------------	
	private bool isLinesIntersect (myLine L1, myLine L2)
	{
		if (checkPoints (L1.StartPoint, L2.StartPoint) ||
			checkPoints (L1.StartPoint, L2.EndPoint) ||
			checkPoints (L1.EndPoint, L2.StartPoint) ||
			checkPoints (L1.EndPoint, L2.EndPoint))
			return false;

		return((Mathf.Max (L1.StartPoint.x, L1.EndPoint.x) >= Mathf.Min (L2.StartPoint.x, L2.EndPoint.x)) &&
			(Mathf.Max (L2.StartPoint.x, L2.EndPoint.x) >= Mathf.Min (L1.StartPoint.x, L1.EndPoint.x)) &&
			(Mathf.Max (L1.StartPoint.y, L1.EndPoint.y) >= Mathf.Min (L2.StartPoint.y, L2.EndPoint.y)) &&
			(Mathf.Max (L2.StartPoint.y, L2.EndPoint.y) >= Mathf.Min (L1.StartPoint.y, L1.EndPoint.y)) 
		);
	}
}