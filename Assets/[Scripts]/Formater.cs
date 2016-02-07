using UnityEngine;
using System.Collections;

public class Formater : MonoBehaviour 
{
	void Start () 
	{
		string cloneStr = "(Clone)";
		if(this.name.Contains(cloneStr))gameObject.name = gameObject.name.Replace(cloneStr, "");
	}
}
