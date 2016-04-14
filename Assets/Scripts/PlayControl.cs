using UnityEngine;
using System.Collections;

public class PlayControl : MonoBehaviour {
	// Use this for initialization
	public static PlayerController[] players = new PlayerController[20];
	public static int counter = 0;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ChangeMode(GameMode changeTo) {
		ControllerModes.mode = changeTo;
		foreach (ModeButton button in GetComponentsInChildren<ModeButton> ()) {
			if (button.modeToChange == ControllerModes.mode) {
				button.GetComponent<SpriteRenderer> ().color = Color.red;
			} else {
				button.GetComponent<SpriteRenderer> ().color = Color.white;
			}
		}
		if (changeTo == GameMode.reset) {
			foreach (PlayerController player in players) {
				if (player != null) {
					player.Reset ();
				}
			}
		}
		if (changeTo == GameMode.play) {
			foreach (PlayerController player in players) {
				if(player != null){
					player.GetComponent<RunController> ().running = true;
				}
			}
		}
	}
}
