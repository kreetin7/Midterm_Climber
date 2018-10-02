using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerTrigger : MonoBehaviour
{

	public Light ComputerLight; 
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter(Collider other)
	{
		ComputerLight.enabled = true; 
	}
}
