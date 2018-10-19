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

	public float jumpForce = 2f;

	private bool grounded;

	

	private Vector3 inputVector;

	 float upDownRotation;

	private AudioSource collisionaudio;

	// Use this for initialization
	void Start()
	{
		rBody = GetComponent<Rigidbody>();
		collisionaudio = GetComponent<AudioSource>();


	}

	// Update is called once per frame
	void Update()
	{
		//camera
		float mouseX = Input.GetAxis("Mouse X") * lookSpeed * Time.deltaTime;
		float mouseY = Input.GetAxis("Mouse Y") * lookSpeed * Time.deltaTime;

		transform.Rotate(0f, mouseX, 0f);
		Camera.main.transform.localEulerAngles += new Vector3(-mouseY, 0f, 0f);
		
		upDownRotation -= mouseY;
		upDownRotation = Mathf.Clamp(upDownRotation, -80, 80); //clamp vertical look rotation between -80 and 80 degrees
	
		Camera.main.transform.localEulerAngles = new Vector3(upDownRotation,0f,0f);

		//movement
		float horizontal = Input.GetAxis("Horizontal");
		Debug.Log(horizontal);
		float vertical = Input.GetAxis("Vertical");
		Debug.Log(vertical);

		inputVector = transform.forward * vertical * moveSpeed;
		inputVector += transform.right * horizontal * moveSpeed;

		//Jump
		float up = -Input.GetAxis("Jump"); //getting the jump axis built into unity

		//Debug.Log(up);
		Ray jumpRay = new Ray(transform.position, Vector3.down); //ray definition
		float jumpRaymaxDist = 1.1f; //distance def
		Debug.DrawRay(jumpRay.origin, jumpRay.direction * jumpRaymaxDist, Color.magenta); //debugging so I can see it when it inevitably fails
		grounded = Physics.Raycast(jumpRay, jumpRaymaxDist);
		if (grounded) //cast that ray
		{
			Debug.Log("Grounded"); //making sure it works
			//inputVector += transform.up * up * jumpSpeed; // pushing it to jump, thank god it works 
			if (Input.GetKey(KeyCode.Space))
			{
				rBody.AddForce(transform.up * jumpForce, ForceMode.VelocityChange);
			}
		}
		

		

		//gravity
	     //inputVector.y += gravity; 
		
		
		if (Input.GetMouseButton(0))
		{
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false; //hide the cursor as well, just to be safe
		}

	}

	void FixedUpdate()
	{
		rBody.velocity = new Vector3(inputVector.x, rBody.velocity.y, inputVector.z);

		if (grounded == false)
		{
			rBody.AddForce(Physics.gravity, ForceMode.Acceleration);
		}
		
	}

	private void OnCollisionEnter(Collision other)
	{
		collisionaudio.PlayOneShot(collisionaudio.clip);
	}
}
