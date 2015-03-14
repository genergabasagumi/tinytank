using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	public float BulletSpeed = 1.0f;
	private float distanceTraveled = 0.0f;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		float x = Mathf.Cos (transform.rotation.y * Mathf.Deg2Rad) * BulletSpeed * Time.deltaTime;
		float y = Mathf.Sin (transform.rotation.y * Mathf.Deg2Rad) * BulletSpeed * Time.deltaTime;
		transform.Translate (x, 0, y);
		distanceTraveled += BulletSpeed * Time.deltaTime;
		if (distanceTraveled > 10.0f) {
			this.enabled = false;
		}
	}

	void OnCollisionEnter (Collision col)
	{
		if(col.gameObject.CompareTag("Wall"))
		{
			this.enabled = false;
		}
		if(col.gameObject.name == "Sphere")
		{
			Destroy(col.gameObject);
			this.enabled = false;
		}
		if(col.gameObject.CompareTag("Player") || col.gameObject.CompareTag("Enemy"))
		{
			TankBase tank = col.gameObject.GetComponent<TankBase>();
			tank.Hurt(1f);
			this.enabled = false;
		}
	}
}
