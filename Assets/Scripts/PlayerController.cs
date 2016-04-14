using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public PlayerPosition position;
	public float weight = 200.0f; //effects the players mass
	public float speed = 3.0f; //effects how quick they run
	public float size = 1.0f; //effects the size of the collider
	public float dodge; 
	public float stamina = 100.0f; // how far the player runs before slowing.
	public float throwStrength;
	private Vector3 initialPos;
	private Quaternion initialRotation;
	// Use this for initialization
	void Start () {
		PlayControl.players [PlayControl.counter] = this;
		PlayControl.counter++;
		initialPos = transform.position;
		initialRotation = transform.rotation;
	}

	public void Reset() {
		transform.position = initialPos;
		transform.rotation = initialRotation;
		GetComponent<RunController> ().Reset ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnMouseDown() {
		switch(ControllerModes.mode){
		case GameMode.run:
			GetComponentInChildren<DrawLine> ().active = true;
			break;
		case GameMode.move:
			GetComponentInChildren<MovePlayer> ().active = true;
			break;
		}
	}
}