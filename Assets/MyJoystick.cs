using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MyJoystick : MonoBehaviour {

public RectTransform mycanvas;
	public Camera cam;

	public RectTransform rt;
	void Update () {
	
		Vector2 ps;
		Vector2 m=new Vector2(Input.mousePosition.x+Screen.width/2.0f,Input.mousePosition.y-Screen.height/2.0f);
		RectTransformUtility.ScreenPointToLocalPointInRectangle(mycanvas,m,null,out ps);
		rt.anchoredPosition=new Vector2(ps.x+rt.sizeDelta.x,ps.y+rt.sizeDelta.y);
	}
}
