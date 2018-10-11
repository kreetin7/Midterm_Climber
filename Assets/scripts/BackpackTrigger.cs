using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackpackTrigger : MonoBehaviour
{

	public Light backpacklight; 
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter(Collider other)
	{
		backpacklight.enabled = true;
	}
}

