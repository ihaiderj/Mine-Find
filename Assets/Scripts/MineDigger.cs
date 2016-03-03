using UnityEngine;
using System.Collections;

public class MineDigger : MonoBehaviour {

	Player player;

	void Start () {
		player = Player.Ins;
	}
	
	void OnTriggerEnter(Collider hit) {
		if (hit.gameObject.name == "MineDiggerColider") {
			player.PlayDigParticle();
		}
	}
}
