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

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (progress == 0 && (CoffeeLight.enabled == false))
		{
			hint.text = "Ugh, another Monday morning. ";
			hint.text += "Better get the coffee going. I really wish I could reach anything without climbing."; 
		}

		if (CoffeeLight.enabled == true)
		{
			progress = 1; 
		}

		if (progress == 1 && (MicrowaveLight.enabled == false))
		{
			hint.text = "Great, coffee's going. ";
			hint.text += "Now for the oatmeal, find the microwave."; 
		}

		if (MicrowaveLight.enabled == true)
		{
			progress = 2; 
		}

		if (progress == 2 && (ComputerLight.enabled == false))
		{
			hint.text = "Oatmeal's going! Crap did I save my paper? Better go do that."; 
		}

		if (ComputerLight.enabled == true)
		{
			progress = 3; 
		}

		if (progress == 3 && (BookLight.enabled == false))
		{
			hint.text = "Whew, crisis averted. Oh wait my books are still up there, gotta grab those."; 
		}

		if (BookLight.enabled == true)
		{
			progress = 4; 
		}

		if (progress == 4 && (FinalLight.enabled == false))
		{
			hint.text = "Great! All set for class, now to just grab my backpack.";
		}

		if (FinalLight.enabled == true)
		{
			progress = 5;
		}

		if (progress == 5)
		{
			hint.text = "Awesome. Time to get out of here or I'm gonna be late.";
			win.text = "You win!";
		}
		
	}
}
