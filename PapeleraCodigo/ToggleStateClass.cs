using UnityEngine;
using System.Collections;

public class ToggleStateClass : MonoBehaviour {

	public bool toggleState;
	
public void toggleStateFunction()
	{
		if (toggleState)
		{
			//Debug.Log("Toggle disabled!");
			animation.Play("DisableSqueeze");
			toggleState=false;
		}
		else
		{
			//Debug.Log("Toggle enabled!");
			animation.Play("EnableSqueeze");
			toggleState=true;
		}
	}
}