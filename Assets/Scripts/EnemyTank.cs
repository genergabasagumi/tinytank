using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyTank : TankBase {
	//private bool searchAndDestroy = false;
	//private float searchDuration = 0.0f;
	private float targetX;
	private float targetY;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		base.Update ();
		if (HitPoints > 0.0f) {
			float h = 1.0f;
			float v = 1.0f;

			if (h != 0 || v != 0) {

				//Randomly change destination
				if(Random.Range(1, 100) > 98) {
					//Random position in ground
					Renderer col = GameManager.instance.level.transform.FindChild("Ground").renderer;
					targetX = Random.Range(-col.bounds.size.x, col.bounds.size.x);
					targetY = Random.Range(-col.bounds.size.z, col.bounds.size.z);
					//Try going towards player instead
					if(Random.Range (1, 100) > 98) {
						targetX = PlayerTank.instance.transform.position.x;
						targetY = PlayerTank.instance.transform.position.z;
					}
				}

				float angle = (Mathf.Atan2(targetX - transform.position.x, targetY - transform.position.z) * Mathf.Rad2Deg) - 90;
				var target = Quaternion.Euler (0, angle, 0);
				transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * 1.0f);

				float x = Mathf.Cos ((transform.rotation.y) * Mathf.Deg2Rad) * MoveSpeed * Time.deltaTime;
				float y = Mathf.Sin ((transform.rotation.y) * Mathf.Deg2Rad) * MoveSpeed * Time.deltaTime;
				transform.Translate (x, 0, y);
			}

			if(Random.Range(1, 100) > 98) Shoot ("Enemy");
		}
	}
}
