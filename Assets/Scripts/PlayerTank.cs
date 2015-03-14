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
		float h = Input.GetAxis ("Horizontal");
		float v = Input.GetAxis ("Vertical");
		Move (h, v);
		if (Input.GetButtonDown ("Jump")) Shoot ("Player");
	}
}
