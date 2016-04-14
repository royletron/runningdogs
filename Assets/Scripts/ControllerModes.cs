using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ControllerModes : MonoBehaviour {

	public static GameMode mode = GameMode.run;
	public static List<PlayerController> players = new List<PlayerController>();
}
