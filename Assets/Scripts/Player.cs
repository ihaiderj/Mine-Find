using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	void Start () {
	
	}
	
	void Update () {
	
	}


	void OnTriggerEnter(Collider other) {
		if(other.CompareTag("MINE")){
			other.SendMessage("BlastMine");
		}
	}
}
