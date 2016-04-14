using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RunController : MonoBehaviour {

	// put the points from unity interface
	private List<Vector3> pointsList;

	private int currentPoint = 0; 
	private Vector3 targetPoint;
	private Vector3 direction;
	private Quaternion qTo;

	private float speed;
	public bool running = false;

	// Update is called once per frame
	void Update () {
		// check if we have somewere to walk
		if(running) {
			if (pointsList == null) {
				speed = GetComponent<PlayerController> ().speed;
				pointsList = this.GetComponent<DrawLine>().pointsList;
				currentPoint = 0;
			}
			if (currentPoint < pointsList.Count) {
				if (targetPoint == null)
					targetPoint = pointsList [currentPoint];
				walk ();
			} else {
				running = false;
			}
		}
	}

	public void Reset() {
		currentPoint = 0;
		running = false;
	}

	void walk(){
		targetPoint = pointsList [currentPoint];
		transform.position = Vector3.MoveTowards(transform.position, targetPoint,   speed*Time.deltaTime);
		Vector3 vectorToTarget = targetPoint - transform.position;
		float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
		Quaternion q = Quaternion.AngleAxis(angle-90, Vector3.forward);
		transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * speed);
		if(transform.position == targetPoint)
		{
			currentPoint ++ ;
		}
	} 
}