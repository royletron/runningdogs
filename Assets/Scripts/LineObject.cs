using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LineObject{

	private GameObject lineObject;
	private LineRenderer line;
	public List<Vector3> pointsList;
	public Color color = Color.red;
	public bool straight = false;
	public bool checkCollide = false;


	struct myLine
	{
		public Vector3 StartPoint;
		public Vector3 EndPoint;
	};

	public LineObject(GameObject parent) {
		lineObject = new GameObject ();
		lineObject.transform.parent = parent.transform;
		line = lineObject.AddComponent<LineRenderer>();
		line.material =  new Material(Shader.Find("Mobile/Particles/Additive"));
		line.SetVertexCount(0);
		line.SetWidth(0.1f,0.1f);
		line.SetColors(color, color);
		line.useWorldSpace = true;	
		pointsList = new List<Vector3>();
	}

	public void ResetLine()
	{
		line.SetVertexCount (0);
		pointsList.RemoveRange(0,pointsList.Count);
		line.SetColors (color, color);
	}

	public void LineToPoint(Vector3 point)
	{
		if (straight) {
			if (pointsList.Count == 0) {
				pointsList.Add (point);
			} else {
				if (pointsList.Count == 1) {
					pointsList.Add (point);
				} else {
					pointsList [1] = point;
				}
			}
			line.SetVertexCount (pointsList.Count);
			line.SetPosition (pointsList.Count - 1, (Vector3)pointsList [pointsList.Count - 1]);
		} else {
			if (!pointsList.Contains (point)) {
				pointsList.Add (point);
				line.SetVertexCount (pointsList.Count);
				line.SetPosition (pointsList.Count - 1, (Vector3)pointsList [pointsList.Count - 1]);
			}

		}
	}

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public bool isLineCollide(Vector3 start, Vector3 end, ref Vector2 intersect)
	{
		Vector2 p3 = new Vector2 (start.x, start.y);
		Vector2 p4 = new Vector2 (end.x, end.y);

		if (pointsList.Count < 2)
			return false;
		int TotalLines = pointsList.Count - 1;
		myLine[] lines = new myLine[TotalLines];
		if (TotalLines > 1) 
		{
			for (int i=0; i<TotalLines; i++) 
			{
				lines [i].StartPoint = (Vector3)pointsList [i];
				lines [i].EndPoint = (Vector3)pointsList [i + 1];
			}
		}
		for (int i=0; i<TotalLines-1; i++) 
		{
//			myLine currentLine;
//			currentLine.StartPoint = start;
//			currentLine.EndPoint = end;
//			if (isLinesIntersect (lines [i], currentLine)) 
//				return true;
			Vector2 p1 = new Vector2 (lines [i].StartPoint.x, lines [i].StartPoint.y);
			Vector2 p2 = new Vector2 (lines [i].EndPoint.x, lines [i].EndPoint.y);
			if (LineIntersection (p1, p2, p3, p4, ref intersect)) {
				Debug.Log (intersect);
				return true;
			}
		}
		return false;
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
	public bool LineIntersection( Vector2 p1,Vector2 p2, Vector2 p3, Vector2 p4, ref Vector2 intersection )
	{

		float Ax,Bx,Cx,Ay,By,Cy,d,e,f,num/*,offset*/;
		float x1lo,x1hi,y1lo,y1hi;

		Ax = p2.x-p1.x;
		Bx = p3.x-p4.x;

		// X bound box test/
		if(Ax<0) {
			x1lo=p2.x; x1hi=p1.x;
		} else {
			x1hi=p2.x; x1lo=p1.x;
		}

		if(Bx>0) {
			if(x1hi < p4.x || p3.x < x1lo) return false;

		} else {
			if(x1hi < p3.x || p4.x < x1lo) return false;
		}

		Ay = p2.y-p1.y;
		By = p3.y-p4.y;

		// Y bound box test//
		if(Ay<0) {                  
			y1lo=p2.y; y1hi=p1.y;
		} else {
			y1hi=p2.y; y1lo=p1.y;
		}

		if(By>0) {
			if(y1hi < p4.y || p3.y < y1lo) return false;
		} else {
			if(y1hi < p3.y || p4.y < y1lo) return false;

		}

		Cx = p1.x-p3.x;
		Cy = p1.y-p3.y;
		d = By*Cx - Bx*Cy;  // alpha numerator//
		f = Ay*Bx - Ax*By;  // both denominator//

		// alpha tests//
		if(f>0) {
			if(d<0 || d>f) return false;
		} else {
			if(d>0 || d<f) return false;
		}

		e = Ax*Cy - Ay*Cx;  // beta numerator//

		// beta tests //
		if(f>0) {                          
			if(e<0 || e>f) return false;
		} else {
			if(e>0 || e<f) return false;
		}

		// check if they are parallel
		if(f==0) return false;
		// compute intersection coordinates //
		num = d*Ax; // numerator //
		//    offset = same_sign(num,f) ? f*0.5f : -f*0.5f;   // round direction //
		//    intersection.x = p1.x + (num+offset) / f;
		intersection.x = p1.x + num / f;

		num = d*Ay;
		//    offset = same_sign(num,f) ? f*0.5f : -f*0.5f;
		//    intersection.y = p1.y + (num+offset) / f;
		intersection.y = p1.y + num / f;

		return true;

	}
}
