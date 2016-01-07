using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour {

	public GameObject homeScreen;
	public GamePlayObjs gamePlay;
	public GameObject hud;
	public void OpenGamePlay(){
		hud.SetActive(true);
		homeScreen.SetActive(false);
		gamePlay.OpenGamePlay(true);
		hud.SetActive(true);
	}

	public void GamePlayToHome(){
		hud.SetActive(false);
		gamePlay.OpenGamePlay(false);
		homeScreen.SetActive(true);

	}
}
