using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : Components {

	public float rotationSpeed=5.0f;
	public Renderer myArea;
	public List<Renderer>colliders;
	public float gravity=-9.8f;
	public float moveSpeed=2.0f;
	public Transform FrontPoint;

	Vector3 lastPosition;
	public Transform playerSkeleton;
	public Transform playerDirection;
	public Transform climbCheckPoint;
	public GameObject animObj;
	public static Transform plrObj;
	public Animator animController;
	public GameObject digButton;
	public GameObject diffuseButton;



	void Awake(){
		plrObj=transform;
		lastPosition=transform.position;
	}

	public bool isMoving=false;

	void Update(){
		if(lastPosition!=transform.position){
			lastPosition=transform.position;
			playerDirection.position=transform.position;
			isMoving=true;

		}
		else isMoving=false;


	}
	private CharacterController player{
		get{
			return GetComponent<CharacterController>();
		}
	}

	private bool wasHitting=false;
	public bool isInAction=false;

	void FixedUpdate(){
		if(isInAction)return;
		Ray r=new Ray(climbCheckPoint.position,climbCheckPoint.forward);
		RaycastHit hit;
		bool isHitting=Physics.Raycast(r,out hit,2.0f,plateFormsLayer);
		
		if(isHitting){
			wasHitting=true;
			transform.Translate(Vector3.up*Time.deltaTime*10.0f,Space.Self);
			return;
		}
		if(wasHitting&&!isHitting){
			wasHitting=false;
			transform.Translate(Vector3.forward*2.5f,Space.Self);
			return;
		}
		Vector3 v=playerDirection.eulerAngles;
		Vector3 directionVector = new Vector3(CnControls.CnInputManager.GetAxis("Horizontal"), 0, CnControls.CnInputManager.GetAxis("Vertical"));
		Vector3 vtmp=animObj.transform.localEulerAngles;
		float angle1=directionVector.x>0?(90.0f*directionVector.x):(360.0f-90.0f*Mathf.Abs(directionVector.x));

		float angle2=(directionVector.z<0.0f?90.0f*directionVector.z:0.0f)*(directionVector.x>0.0f?-1.0f:1.0f);

		FrontPoint.localEulerAngles=Quaternion.Euler(0.0f,angle1+angle2,0.0f).eulerAngles;
		animObj.transform.localEulerAngles=Quaternion.Euler(0.0f,angle1+angle2,0.0f).eulerAngles;

		Vector3 dir=FrontPoint.forward*directionVector.magnitude;
		dir.y=gravity;
		player.Move(dir*moveSpeed);
		if(directionVector!=Vector3.zero)SetAnimIntIds("walk",animController);
		else SetAnimIntIds("idle",animController);//

		Vector3 rotationDir = new Vector3(CnControls.CnInputManager.GetAxis("YRot"), 0, CnControls.CnInputManager.GetAxis("XRot"));

		if(rotationDir!=Vector3.zero){
			v.y+=rotationDir.x*rotationSpeed;
			playerDirection.eulerAngles=v;
			transform.eulerAngles=v;
		}
	}

	public void DigAnims(){
		isInAction=true;
		SetAnimIntIds("dig",animController);
		digButton.SetActive(false);
		StartCoroutine(DigFinish());
	}

	IEnumerator DigFinish(){
		yield return new WaitForSeconds(1.2f);
		SetAnimIntIds("idle",animController);//
		diffuseButton.SetActive(true);
	}

	public void Difuse(){
		diffuseButton.SetActive(false);
		SetAnimIntIds("diffuse",animController);
		StartCoroutine(Difused());
	}
	IEnumerator Difused(){
		yield return new WaitForSeconds(1.2f);
		SetAnimIntIds("idle",animController);//
		diffuseButton.SetActive(false);
		Destroy(MineDefuser.T.foundMine.GetComponent<Mine>().effect);
		MineDefuser.T.joyStics.SetActive(true);
		isInAction=false;
	}

	public void JumpOn(){
		Vector3 v=transform.position+Vector3.up*6.0f;
		v+=transform.forward*4.0f;
		transform.position=v;
	}
	void OnTriggerEnter(Collider hit) {
		if(hit.transform.gameObject.layer==8){
			Vector3 v=transform.position+Vector3.up*6.0f;
			v+=transform.forward*4.0f;
			transform.position=v;
			//GetComponent<Player>().falling=false;

		}
//		Debug.Log(hit.collider.name);
	}
	public Vector2 Axis(){
		float x=Input.GetAxis("Horizontal");
		float y=Input.GetAxis("Vertical");
		return new Vector2(x,y);
	}

	public LayerMask plateFormsLayer;
	public void CheckClimbingStatus(){
		Ray r=new Ray();
	}


	public static void SetAnimIntIds(int id,string key,Animator animtr){

		int id1=animtr.GetInteger(key);

		if(id1!=id){
			animtr.SetInteger(key,id);
		}
	}

	private static string currentAnim;
	public static void SetAnimIntIds(string key,Animator animtr){
		
		if(currentAnim!=key){
			animtr.SetTrigger(key);
		}
		currentAnim=key;
	}
}

