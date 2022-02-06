using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch_action : MonoBehaviour{

    public GameObject Switch;
    public bool switchIsOn;
	Color colorOn = Color.green;
	Color colorOff = Color.red;
	
    void OnMouseDown(){ //THIS FUNCTION WILL DETECT THE MOUSE CLICK ON A COLLIDER,IN OUR CASE WILL DETECT THE CLICK ON THE BUTTON
		// Get the renderer from Switch
		var switchRenderer = Switch.GetComponent<Renderer>(); 
		if (switchIsOn == false){
			switchIsOn = true;
			switchRenderer.material.SetColor("_Color",colorOn);
		}
		else{
			switchIsOn = false;
			switchRenderer.material.SetColor("_Color",colorOff);
		}
       
    }

}