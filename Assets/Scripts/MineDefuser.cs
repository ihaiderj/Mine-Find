using UnityEngine;
using System.Collections;

public class MineDefuser : MonoBehaviour {
	private static GameObject ob;
	public static MineDefuser T{get{return ob.GetComponent<MineDefuser>();}}
	public GameObject foundMine;
	public GameObject joyStics;
	public GameObject digButton;
	private void Update(){

	}

	private void Awake(){
		ob=gameObject;
	}
	private void Start(){

	}

	public void OnMineFound(GameObject mn){
		foundMine=mn;
		joyStics.SetActive(false);
		digButton.SetActive(true);
	}
}
