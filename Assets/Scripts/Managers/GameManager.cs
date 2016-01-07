using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	private static GameObject obj;
	public static GameManager Instance{get{return obj.GetComponent<GameManager>();}}

	void Awake(){
		obj=gameObject;
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