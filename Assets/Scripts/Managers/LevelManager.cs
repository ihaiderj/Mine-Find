using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour {

	int levelId;
	int levelMines;
	int levelTime;
	int maxLevelId;

	public Levels currLevel;
	public List<Levels> level_list;

	static LevelManager ins;
	public static LevelManager Ins{
		get{
			if(ins == null){
				ins = FindObjectOfType<LevelManager>();
			}
			return ins;
		}
	}

	public void CloseThisPannel(){
		gameObject.SetActive(false);
	}
	public void OpenSettings(){
		gameObject.SetActive(true);
	}

	public void InitLevel(int levelId){
		currLevel = level_list [levelId - 1];
		levelId = int.Parse(currLevel.id);
		levelMines = currLevel.mines;
		levelTime = currLevel.time;
	}

	public int GetLevelId(){
		return levelId;
	}
	public int GetMaxLevelId(){
		return maxLevelId;
	}
	public int GetLevelMines(){
		return levelMines;
	}
	public int GetLevelTime(){
		return levelTime;
	}

	public int LevelTime(){
		return currLevel.time;
	}

	[System.Serializable]
	public class Levels{
		public string id;
		public int mines;
		public int time;
	}
}
