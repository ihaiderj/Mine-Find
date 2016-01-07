using UnityEngine;
using System.Collections;

public class Mine : MonoBehaviour {

	bool isBlasted;

	void Start () {
		isBlasted = false;
	}

	public void BlastMine(){
		if(isBlasted)return;
		isBlasted = true;
		//GameManager.Ins.ShakeCamera();
		GetComponentInChildren<ParticleSystem>().Play();
	}
}