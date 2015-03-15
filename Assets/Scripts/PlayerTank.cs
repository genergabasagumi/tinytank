using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PlayerTank : TankBase {
	public static PlayerTank instance;

	// Use this for initialization
	void Start () {
		instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		base.Update ();
		float h = GameManager.instance.Joystick.GetAxis ("Horizontal");
		float v = GameManager.instance.Joystick.GetAxis ("Vertical");

		if (h != 0 || v != 0) {
			float angle = (Mathf.Atan2(h, v) * Mathf.Rad2Deg) - 90;
			var target = Quaternion.Euler (0, angle, 0);
			transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * 10.0f);

			float x = Mathf.Cos ((transform.rotation.y) * Mathf.Deg2Rad) * MoveSpeed * Time.deltaTime;
			float y = Mathf.Sin ((transform.rotation.y) * Mathf.Deg2Rad) * MoveSpeed * Time.deltaTime;
			transform.Translate (x, 0, y);
		}

		if (Input.touchCount > 0 ) {
			for (var i = 0; i < Input.touchCount; ++i) {
				if (Input.GetTouch(i).phase == TouchPhase.Began)
					Shoot ("Player");
			}
		}
		if (Input.GetButtonDown ("Jump")) Shoot ("Player");
	}

	private static float UnwrapAngle(float angle) {
		if (angle > 359)
			return angle - 360;
		if (angle < 0)
			return angle + 360;
		return angle;
	}

}
