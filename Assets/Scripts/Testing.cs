using UnityEngine;
using System.Collections;

public class Testing : MonoBehaviour {

	public bool isTesting;
	public int testLevelId;

	static Testing ins;
	public static Testing Ins{
		get{
			if(ins == null){
				ins = FindObjectOfType<Testing>();
			}
			return ins;
		}
	}

	void Awake(){
		if (isTesting) {
			UIManager.Ins.LevelNo(testLevelId);
		}
	}

	void Start () {
	
	}
}
