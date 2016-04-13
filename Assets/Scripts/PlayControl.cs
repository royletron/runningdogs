using UnityEngine;
using System.Collections;

public class PlayControl : MonoBehaviour {
	public GameMode mode = GameMode.run;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ChangeMode(GameMode changeTo) {
		print (changeTo);
	}
}
