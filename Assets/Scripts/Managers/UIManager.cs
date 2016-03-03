using UnityEngine;
using System;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	public GameObject homeScreen;
	public GamePlayObjs gamePlay;
	public GameObject hud;
	public GameObject mapCam;

	public Text minesTxt;
	public Text timerTxt;

	int levelTime;
	int levelMines;

	LevelManager levelManager;

	static UIManager ins;
	public static UIManager Ins{
		get{
			if(ins == null){
				ins = FindObjectOfType<UIManager>();
			}
			return ins;
		}
	}

	void Start(){
		levelManager = LevelManager.Ins;
	}

	void OnEnable(){
		Player.OnDiffused += OnDiffusedHandler;
	}
	void OnDisable(){
		Player.OnDiffused -= OnDiffusedHandler;
	}

	void OnDiffusedHandler (){
		levelMines--;
		minesTxt.text = string.Format("Remaining: " + levelMines);
	}

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
		mapCam.SetActive(false);

		StopTimer ();
	}
	public void OnClickMap(){
		mapCam.SetActive(!mapCam.activeSelf);
	}
	public void LevelNo(int levelId){
		levelManager = LevelManager.Ins;
		levelManager.InitLevel (levelId);
		levelTime = levelManager.GetLevelTime ();
		levelMines = levelManager.GetLevelMines ();
		minesTxt.text = string.Format("Remaining: " + levelMines);
		StartTimer ();
	}

	public void StartTimer(){
		StopTimer ();
		InvokeRepeating ("Timer", 1, 1);
	}
	void Timer(){
		if (levelTime <= 0) {
			StopTimer();
			return;
		}
		--levelTime;
		timerTxt.text = string.Format ("Time: {0}:{1:00}", levelTime/60, levelTime%60);
	}
	public void StopTimer(){
		if(IsInvoking("Timer")){
			CancelInvoke("Timer");
		}
	}
}
