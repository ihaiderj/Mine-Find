using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Player2 : Components {

	public float speed=5.0f;
	public List<Renderer>colliders;
	public Renderer myArea;
	private Vector3 lastPosition;

	private void Awake(){
		lastPosition=transform.position;
	}

	void Update(){
		if(lastPosition!=transform.position){
			lastPosition=transform.position;
			for(int i=0;i<colliders.Count;i++){
				Bounds bound1=colliders[i].bounds;
				Bounds bound2=myArea.bounds;
				if(bound1.Intersects(bound2))colliders[i].GetComponent<Collider>().enabled=true;
				else colliders[i].GetComponent<Collider>().enabled=false;
			}
		}
	}
	void FixedUpdate(){
		Vector3 v=transform.eulerAngles;
		Vector3 directionVector = new Vector3(CnControls.CnInputManager.GetAxis("Horizontal"), 0, CnControls.CnInputManager.GetAxis("Vertical"));
		gameObject.SendMessage("GetInputData",directionVector.magnitude,SendMessageOptions.DontRequireReceiver);
		if(directionVector!=Vector3.zero){
			v.y+=directionVector.x*speed;
			transform.eulerAngles=v;
			gameObject.GetComponent<Animation>().CrossFade("Take 001");

		}
		else gameObject.GetComponent<Animation>().Stop();
	}


	public Vector2 Axis(){

		float x=Input.GetAxis("Horizontal");
		float y=Input.GetAxis("Vertical");
		return new Vector2(x,y);
	}



}
