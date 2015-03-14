using UnityEngine;
using System.Collections;

public class ButtonScript : MonoBehaviour {
	public static ButtonScript instance;
	public GameObject MainMenu;
	public GameObject PauseMenu;
	public GameObject OptionsMenu;
	public GameObject Achievements;
	public GameObject Leaderboards;
	public GameObject Help;
	public GameObject About;
	public GameObject GameOver;
	public GameObject HUD;
	public GameObject TankGame;

	public void Awake() {
		ShowMainMenu ();
	}

	public void Start() {
		instance = this;
	}

	public void StartGame() {
		DeactivateAll ();

		HUD.SetActive (true);
		TankGame.SetActive(true);
		GameManager.instance.init ();
	}

	public void PauseGame() {
		DeactivateAll ();

		PauseMenu.SetActive (true);
	}

	//use on resume or retry
	public void ResumeGame(bool retry) {
		DeactivateAll ();

		HUD.SetActive (true);
		TankGame.SetActive(true);
		//reinitialize mission on retry
		if (retry) {
			GameManager.instance.init();
		}
	}
	
	public void ShowMainMenu() {
		GameManager.instance.destroy ();
		DeactivateAll ();

		MainMenu.SetActive (true);
	}

	public void ShowLeaderboards() {
		DeactivateAll ();
		
		Leaderboards.SetActive (true);
	}
	
	public void ShowAchievements() {
		DeactivateAll ();
		
		Achievements.SetActive (true);
	}
	
	public void ShowOptions() {
		DeactivateAll ();
		
		OptionsMenu.SetActive (true);
	}
	
	public void ShowHelp() {
		DeactivateAll ();
		
		Help.SetActive (true);
	}
	
	public void ShowAbout() {
		DeactivateAll ();
		
		About.SetActive (true);
	}
	
	public void ShowGameOver() {
		DeactivateAll ();
		GameManager.instance.destroy ();
		GameOver.SetActive (true);
	}
	
	private void DeactivateAll() {
		MainMenu.SetActive (false);
		PauseMenu.SetActive (false);
		OptionsMenu.SetActive (false);
		Achievements.SetActive (false);
		Leaderboards.SetActive (false);
		Help.SetActive (false);
		About.SetActive (false);
		GameOver.SetActive (false);
		HUD.SetActive (false);
		TankGame.SetActive (false);
	}
}
