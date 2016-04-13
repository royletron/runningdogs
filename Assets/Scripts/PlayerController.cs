using UnityEngine;
using System.Collections;

public enum playPosition {linebacker, quarterback}

public class PlayerController : MonoBehaviour {
	public PlayerPosition position;
	public float weight;
	public float speed;
	public float dodge;
	public float throwStrength;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnMouseDown() {
		GetComponent<DrawLine> ().active = true;
	}
}
