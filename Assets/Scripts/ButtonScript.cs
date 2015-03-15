using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ButtonScript : MonoBehaviour {
	public static ButtonScript instance;
	public List<GameObject> objects;

	public void Awake() {
		ShowMainMenu ();
	}

	public void Start() {
		instance = this;
	}

	public void StartGame() {
		DeactivateAll ();

		SetActive ("HUD", true);
		SetActive ("TankGame", true);
		GameManager.instance.init ();
	}

	public void PauseGame() {
		DeactivateAll ();

		SetActive ("PauseMenu", true);
	}

	//use on resume or retry
	public void ResumeGame(bool retry) {
		DeactivateAll ();

		SetActive ("HUD", true);
		SetActive ("TankGame", true);
		//reinitialize mission on retry
		if (retry) {
			GameManager.instance.init();
		}
	}
	
	public void ShowMainMenu() {
		GameManager.destroy ();
		DeactivateAll ();

		SetActive ("MainMenu", true);
	}

	public void ShowLeaderboards() {
		DeactivateAll ();
		
		SetActive ("Leaderboards", true);
	}
	
	public void ShowAchievements() {
		DeactivateAll ();
		
		SetActive ("Achievements", true);
	}
	
	public void ShowOptions() {
		DeactivateAll ();
		
		SetActive ("OptionsMenu", true);
	}
	
	public void ShowHelp() {
		DeactivateAll ();
		
		SetActive ("Help", true);
	}
	
	public void ShowAbout() {
		DeactivateAll ();
		
		SetActive ("About", true);
	}
	
	public void ShowGameOver() {
		DeactivateAll ();
		GameManager.destroy ();
		SetActive ("GameOver", true);
	}
	
	private void DeactivateAll() {
		foreach (GameObject obj in objects) {
			obj.SetActive(false);
		}
	}

	private void SetActive(string name, bool active) {
		foreach (GameObject obj in objects) {
			if(obj.name == name) obj.SetActive(active);
		}
	}
}
