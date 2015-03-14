using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyTank : TankBase {
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		base.Update ();
		if (HitPoints > 0.0f) {
			float h = 0.0f;
			float v = 1.0f;
			Move (h, v);
			if(Random.Range(1, 100) > 98) Shoot ("Enemy");
		}
	}
}
