using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextScript : MonoBehaviour
{

	public int progress = 0;
	public Text hint;
	public Text win; 

	public Light CoffeeLight;
	public Light MicrowaveLight;
	public Light ComputerLight;
	public Light BookLight;
	public Light FinalLight;

	public GameObject ArrowMan; 
	

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (progress == 0 && (CoffeeLight.enabled == false))
		{
			hint.text = "Ugh, another Monday morning. ";
			hint.text += "Better get the coffee going. I really wish I could reach anything without climbing."; 
			ArrowMan.transform.position= new Vector3 (-3.17f, 10.11f, -15.34f);
		}

		if (CoffeeLight.enabled == true)
		{
			progress = 1; 
		}

		if (progress == 1 && (MicrowaveLight.enabled == false))
		{
			hint.text = "Great, coffee's going. ";
			hint.text += "Now for the oatmeal, find the microwave."; 
			ArrowMan.transform.position = new Vector3(9.8f, 7.34f, 1.68f);
		}

		if (MicrowaveLight.enabled == true)
		{
			progress = 2; 
		}

		if (progress == 2 && (ComputerLight.enabled == false))
		{
			hint.text = "Oatmeal's going! Crap did I save my paper? Dammit that's the hardest place to climb. Better go do that."; 
			ArrowMan.transform.position = new Vector3(-3.51f, 8.2f, 9.55f);
		}

		if (ComputerLight.enabled == true)
		{
			progress = 3; 
		}

		if (progress == 3 && (BookLight.enabled == false))
		{
			hint.text = "Whew, crisis averted. Oh wait my books for today are on the top shelf? Gotta grab those."; 
			ArrowMan.transform.position = new Vector3(-3.9f, 10.57f, 9.55f);
		}

		if (BookLight.enabled == true)
		{
			progress = 4; 
		}

		if (progress == 4 && (FinalLight.enabled == false))
		{
			hint.text = "Great! All set for class, now to just grab my backpack.";
			ArrowMan.transform.position = new Vector3(-5.22f, 10.33f, 2.52f);
		}

		if (FinalLight.enabled == true)
		{
			progress = 5;
		}

		if (progress == 5)
		{
			hint.text = "Awesome. Time to get out of here or I'm gonna be late.";
			win.text = "You win!";
			win.text += " Press R to restart. ";
			ArrowMan.transform.position = new Vector3(-20f, -20f, -20f);
		}

		if (Input.GetKey(KeyCode.R))
		{
			progress = 0;
			CoffeeLight.enabled = false;
			MicrowaveLight.enabled = false;
			ComputerLight.enabled = false;
			BookLight.enabled = false;
			FinalLight.enabled = false;
			win.text = "";
			ArrowMan.transform.position= new Vector3 (-3.17f, 10.11f, -15.34f);

		}
		
		if (Input.GetKey(KeyCode.P))
		{
			progress = 5;
		}
	}
}
