using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class CoffeeTrigger : MonoBehaviour
{
	public Light coffeeMachine;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter(Collider other)
	{
		coffeeMachine.enabled = true;
	}
}
