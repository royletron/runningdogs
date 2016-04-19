using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LineObject{

	private GameObject lineObject;
	private LineRenderer line;
	public List<Vector3> pointsList;

	public LineObject() {
		lineObject = new GameObject ();
		line = lineObject.AddComponent<LineRenderer>();
		line.material =  new Material(Shader.Find("Particles/Additive"));
		line.SetVertexCount(0);
		line.SetWidth(0.0f,0.1f);
		line.SetColors(Color.red, Color.red);
		line.useWorldSpace = true;	
		pointsList = new List<Vector3>();
	}

	public void ResetLine(Color col)
	{
		line.SetVertexCount (0);
		pointsList.RemoveRange(0,pointsList.Count);
		line.SetColors (col, col);
	}

	public void LineToPoint(Vector3 point)
	{
		if (!pointsList.Contains (point)) 
		{
			pointsList.Add (point);
			line.SetVertexCount (pointsList.Count);
			line.SetPosition (pointsList.Count - 1, (Vector3)pointsList [pointsList.Count - 1]);
		}
	}

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
