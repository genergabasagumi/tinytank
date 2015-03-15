using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	public static GameManager instance;

	//Level
	public GameObject level;		//Instanciate from Prefab
	private List<Transform> spawnPoints = new List<Transform>();
	private Transform heroSpawnPoint;
	public GameObject currentLevel = null;

	//Enemy
	public GameObject enemyTank;	//Instanciate from Prefab
	public float spawnInterval = 10f;
	private bool spawning = true;

	//Player
	public GameObject playerTank;	//Instanciate from Prefab

	public Camera camera;
	public CNJoystick Joystick;
	int score;

	void Awake() {
		instance = this;
	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator Spawn() {
		while (spawning) {
			int numSpawnPoints = spawnPoints.Count;
			Vector3 spawnPos = Vector3.zero;
			int spawnPointIndex = Random.Range (1, numSpawnPoints);
			Debug.Log("Spawning at " + spawnPointIndex);
			spawnPos = spawnPoints [spawnPointIndex].position;
			(Instantiate (enemyTank, spawnPos, Quaternion.identity) as GameObject).transform.parent = currentLevel.transform;
			yield return new WaitForSeconds (spawnInterval);
		}
	}

	public void init() {
		if (currentLevel == null) {
			Debug.Log ("Initializing game...");
			currentLevel = Instantiate (level) as GameObject;
			currentLevel.transform.parent = transform;
			spawnPoints.Clear ();
			for (int i = 0; i < currentLevel.transform.childCount; i++) {
				Transform child = currentLevel.transform.GetChild (i);
				if (child.name == "SpawnPoint") {
					spawnPoints.Add (child);
				}
				if (child.name == "HeroSpawnPoint") {
					heroSpawnPoint = child;
				}
			}
			Debug.Log ("Total spawn points " + spawnPoints.Count);
			spawning = true;
			StartCoroutine ("Spawn");
			GameObject hero = Instantiate (playerTank, heroSpawnPoint.position, Quaternion.identity) as GameObject;
			hero.transform.parent = currentLevel.transform;
			camera.GetComponent<UnitySampleAssets.Utility.FollowTarget> ().target = hero.transform;
		}
	}

	public static void destroy() {
		if (instance != null) {
			instance.spawning = false;
			if (instance.currentLevel != null) {
				Destroy (instance.currentLevel);
				instance.currentLevel = null;
			}
		}
	}

	public void AddScore(int value) {
		score += value;
		GameObject.Find ("UI/root/HUD/Coins/Text").GetComponent<Text> ().text = score.ToString();
	}
}
