using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//put on capsule player
//first person controller of player model, handels movement and looking
public class PersonController : MonoBehaviour
{
	private Rigidbody rBody;

	//public float gravity = 40f; 

	public float moveSpeed = 20f;
	public float lookSpeed = 100f;
	public float jumpSpeed = 0.5f;

	private Vector3 inputVector;

	//public Transform Groundcheck;
	//public float groundcheckRadius;
	//public LayerMask whatisGrounded;
	//private bool Grounded;


	//private Vector3 MoveDirection = Vector3.zero;

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

		//jump? 

		float up = Input.GetAxis("Jump");

		inputVector -= transform.up * up * jumpSpeed;

		//gravity
		//MoveDirection.y = gravity * Time.deltaTime; 








	}

	void FixedUpdate()
	{
		rBody.velocity = inputVector;
		//grounded
		/*Grounded = Physics2D.OverlapCircle(Groundcheck.position, groundcheckRadius, whatisGrounded);

		if (Input.GetKeyDown(KeyCode.Space))
		{
			//no double-jump
			if (Grounded)
			{
				rBody.velocity = new Vector2(rBody.velocity.x, jumpSpeed);
			}
		}*/
	}
}
