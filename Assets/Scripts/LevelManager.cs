using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public void CloseThisPannel(){
		gameObject.SetActive(false);
	}
	public void OpenSettings(){
		gameObject.SetActive(true);
	}
}
