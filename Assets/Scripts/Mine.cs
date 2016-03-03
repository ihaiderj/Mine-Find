using UnityEngine;
using System.Collections;

public class Mine : MonoBehaviour {

	bool isBlasted=false;
	bool isTriggered=false;
	bool isDigging=false;

	public GameObject effect;

	void Update(){
		if(!isTriggered){
			if(Player.plrObj!=null){					
				float dist=Vector3.Distance(transform.position,Player.plrObj.position);
				if(dist<10.0f){
					isTriggered=true;
					GameManager.Instance.ReachedNearToMine(transform);
				}
			}
		}
		else{
			if(!isDigging){
				float dist=Vector3.Distance(transform.position,Player.plrObj.position);
				if(dist<2.0f){
					isDigging=true;
					MineDefuser.T.OnMineFound(gameObject);
				}
			}
		}
	}
}