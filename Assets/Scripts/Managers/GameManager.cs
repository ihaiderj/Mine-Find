using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class GameManager : MonoBehaviour {

	private static GameObject obj;
	public static GameManager Instance{get{return obj.GetComponent<GameManager>();}}
	public GameObject detecterEffect;
	public Transform mineParent;

	void Awake(){
		obj=gameObject;
	}

	void Start(){
		EnableMines();
	}

	public void EnableMines(){
		List<Mine>mines=new List<Mine>(mineParent.GetComponentsInChildren<Mine>());

		int rCount=Random.Range(10,20);
		int cnt=0;
		List<Mine>mines2=new List<Mine>();
		while(cnt<rCount){
			int number=Random.Range(0,mines.Count-1);
			mines2.Add(mines[number]);
			mines.RemoveAt(number);
			cnt++;
		}

		for(int i=0;i<mines.Count;i++){
			mines[i].gameObject.SetActive(false);
		}
	}


	public void ReachedNearToMine(Transform mineobj){
		GameObject g=(GameObject)Instantiate(detecterEffect);
		g.transform.position=mineobj.position;
		g.SetActive(true);
		mineobj.GetComponent<Mine>().effect=g;

	}


}
[System.Serializable]
public struct GamePlayObjs{
	public GameObject player;
	public GameObject cam;

	public void OpenGamePlay(bool openclose){
		player.SetActive(openclose);
		cam.SetActive(openclose);
	}

}