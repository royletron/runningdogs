using UnityEngine;
using System.Collections;

public enum team {
	home, away
}

public class PlayerController : MonoBehaviour {
	public PlayerPosition position;
	public float weight = 200.0f; //effects the players mass
	public float speed = 3.0f; //effects how quick they run
	public float size = 1.0f; //effects the size of the collider
	public float dodge; 
	public float stamina = 100.0f; // how far the player runs before slowing.
	public float throwStrength;
	public team side = team.home;
	private Vector3 initialPos;
	private Quaternion initialRotation;
	public Sprite awaySprite;
	public Sprite homeSprite;

	public LineObject runLine;
	public LineObject throwLine;
	private DrawLine drawLine;
	// Use this for initialization
	void Awake()
	{
		PlayControl.players [PlayControl.counter] = this;
		PlayControl.counter++;
		runLine = new LineObject (this.gameObject);
		runLine.color = Color.blue;
		throwLine = new LineObject (this.gameObject);
		throwLine.straight = throwLine.checkCollide = true;
		throwLine.color = Color.red;
		initialPos = transform.position;
		initialRotation = transform.rotation;
		drawLine = GetComponentInChildren<DrawLine> ();
	}

	void OnValidate() {
		if (this.side == team.home) {
			this.GetComponent<SpriteRenderer> ().sprite = homeSprite;
		} else {
			this.GetComponent<SpriteRenderer> ().sprite = awaySprite;
		}
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
			drawLine.currentLine = runLine;
			drawLine.active = true;
			break;
		case GameMode.pass:
			drawLine.currentLine = throwLine;
			drawLine.active = true;
			break;
		case GameMode.move:
			GetComponentInChildren<MovePlayer> ().active = true;
			break;
		}
	}
}