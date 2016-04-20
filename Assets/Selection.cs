using UnityEngine;
using System.Collections;

public class Selection : MonoBehaviour {

	// Use this for initialization
	public bool toSelect = false;
	public Sprite selectSprite;
	public Sprite highlightSprite;
	public bool pulse = false;
	public float speed = 1.0f;

	private bool pulseUp = false;

	void OnValidate() {
		if (toSelect) {
			this.GetComponent<SpriteRenderer> ().sprite = selectSprite;
		} else {
			this.GetComponent<SpriteRenderer> ().sprite = highlightSprite;
		}
	}

	// Update is called once per frame
	void Update () {
		if(pulse)
		{
			SpriteRenderer sprite = this.GetComponent<SpriteRenderer> ();
//			if(pulseUp){
//				if (sprite.color.a > 1) {
//					pulseUp = false;
//				} else {
//					sprite.color
//					sprite.color.a += speed * Time.deltaTime;
//				}
//			}
//			else{
//				if (sprite.color.a < 0.1) {
//					pulseUp = true;
//				} else{
//					sprite.color.a += -speed *Time.deltaTime;
//				}
//			}
		}
	}
}
