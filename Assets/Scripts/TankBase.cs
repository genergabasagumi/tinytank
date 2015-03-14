using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class TankBase : MonoBehaviour {
	public float HitPoints = 10.0f;
	public float MoveSpeed = 3.0f;
	public float TurnAngle = 360.0f;
	public GameObject BulletObject;	//Prefab Object
	public GameObject VFXObject;	//Prefab Object
	private List<GameObject> bullets = new List<GameObject>();
	private List<GameObject> effects = new List<GameObject>();
	
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	public void Update () {
		transform.FindChild ("cartoon tank/BarrelTip").GetComponent<Light> ().enabled = false;
		UpdateBullets ();
		UpdateEffects ();
	}

	public void Move(float h, float v) {
		//reverse turn direction when backing
		if (v < 0) {
			h = -h;
		}
		transform.Rotate (0, TurnAngle * h * Time.deltaTime, 0);
		float x = Mathf.Cos (transform.rotation.y * Mathf.Deg2Rad) * MoveSpeed * v * Time.deltaTime;
		float y = Mathf.Sin (transform.rotation.y * Mathf.Deg2Rad) * MoveSpeed * v * Time.deltaTime;
		transform.Translate (x, 0, y);
	}

	public void Shoot(string shooter) {
		transform.FindChild ("cartoon tank/BarrelTip").GetComponent<Light> ().enabled = true;
		GameObject obj = Instantiate(BulletObject, transform.FindChild("cartoon tank/BarrelTip").position, transform.rotation) as GameObject;
		obj.tag = shooter;
		obj.transform.parent = GameManager.instance.currentLevel.transform;
		bullets.Add(obj);
	}

	private void UpdateBullets() {
		//Manage bullets
		foreach (GameObject obj in bullets) {
			Bullet bullet = obj.GetComponent<Bullet> ();
			if (!bullet.enabled) {
				//effects.Add(Instantiate (VFXObject, obj.transform.position, Quaternion.identity) as GameObject);
				bullets.Remove (obj);
				Destroy (obj);
				break;
			}
		}
	}

	private void UpdateEffects() {
		foreach (GameObject obj in effects) {
			ParticleSystem effect = obj.transform.FindChild("Exposion-[Explosion6]").GetComponent<ParticleSystem> ();
			if (!effect.isPlaying) {
				effects.Remove(obj);
				Destroy(obj);
				break;
			}
		}
	}
	
	public void Hurt(float damage) {
		HitPoints -= damage;
		if (CompareTag("Player")) {
			GameObject.Find ("UI/root/HUD/Health/Fill").GetComponent<Image> ().fillAmount = HitPoints / 10;
			if (HitPoints <= 0) {
				ButtonScript.instance.ShowGameOver ();
			}
		} else if(CompareTag("Enemy")) {
			GameManager.instance.AddScore(1);
			if (HitPoints <= 0) {
				GameManager.instance.AddScore(100);
				Destroy (gameObject);
			}
		}

	}
}
