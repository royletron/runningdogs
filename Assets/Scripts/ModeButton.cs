using UnityEngine;
using System.Collections;

public class ModeButton : MonoBehaviour {
	public GameMode modeToChange;
	private PlayControl controller;
	// Use this for initialization
	void Start () {
		controller = GetComponentInParent<PlayControl> ();
	}
	void OnMouseDown() {
		controller.ChangeMode (modeToChange);
	}
}
