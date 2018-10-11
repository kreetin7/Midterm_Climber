using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//put on capsule player
//first person controller of player model, handels movement, jumping and looking
//(future ren when you ineveitably forget how to jump because your brain has a goldfish memory this is the script to look at) 
public class PersonController : MonoBehaviour
{
	private Rigidbody rBody;

	public float gravity = 1f; 

	public float moveSpeed = 20f;
	public float lookSpeed = 100f;
	public float jumpSpeed = 10f;

	

	private Vector3 inputVector;

	


	

	// Use this for initialization
	void Start()
	{
		rBody = GetComponent<Rigidbody>();

	
	}

	// Update is called once per frame
	void Update()
	{
		//camera
		float mouseX = Input.GetAxis("Mouse X") * lookSpeed * Time.deltaTime;
		float mouseY = Input.GetAxis("Mouse Y") * lookSpeed * Time.deltaTime;

		transform.Rotate(0f, -mouseX, 0f);
		Camera.main.transform.localEulerAngles += new Vector3(mouseY, 0f, 0f);
		Camera.main.transform.localEulerAngles -= new Vector3(0f, 0f, Camera.main.transform.localEulerAngles.z);

		//movement
		float horizontal = Input.GetAxis("Horizontal");
		float vertical = Input.GetAxis("Vertical");

		inputVector = transform.forward * vertical * moveSpeed;
		inputVector += transform.right * horizontal * moveSpeed;

		//Jump
		float up = -Input.GetAxis("Jump"); //getting the jump axis built into unity

		Debug.Log(up);
		Ray jumpRay = new Ray(transform.position, Vector3.down); //ray definition
		float jumpRaymaxDist = 1.5f; //distance def
		Debug.DrawRay(jumpRay.origin, jumpRay.direction * jumpRaymaxDist, Color.magenta); //debugging so I can see it when it inevitably fails
		if (Physics.Raycast(jumpRay, jumpRaymaxDist)) //cast that ray
		{
			Debug.Log("Grounded"); //making sure it works
			inputVector = inputVector + transform.up * up * jumpSpeed; // pushing it to jump, thank god it works 
		}
		

		

		//gravity
	     inputVector.y += gravity; 


	}

	void FixedUpdate()
	{
		rBody.velocity = inputVector;


		
	}

	
}
