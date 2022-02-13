using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch_action : MonoBehaviour{

    public GameObject Switch;
    public bool switchIsOn;
	Color colorOn = Color.green;
	Color colorOff = Color.red;
	public GameObject Axis;
	public GameObject ButtonMotor;

	
    void OnMouseDown(){ //THIS FUNCTION WILL DETECT THE MOUSE CLICK ON A COLLIDER,IN OUR CASE WILL DETECT THE CLICK ON THE BUTTON
		// Get the renderer from Switch
		var switchRenderer = Switch.GetComponent<Renderer>(); 
		var hinge = Axis.GetComponent<HingeJoint>();
		var motor = hinge.motor;
		var AxisRigidbody = Axis.GetComponent<Rigidbody>();
		AxisRigidbody.freezeRotation = true;
		var motorButtonRenderer = ButtonMotor.GetComponent<Renderer>(); 
		
		var colorButtonMotor = Switch.GetComponent<Switch_action>();
		
		if (switchIsOn == false){
			switchIsOn = true;
			switchRenderer.material.SetColor("_Color",colorOn);
		}
		else{
			switchIsOn = false;
			switchRenderer.material.SetColor("_Color",colorOff);
			hinge.useMotor = false;
			AxisRigidbody.freezeRotation = true;
			motorButtonRenderer.material.SetColor("_Color",colorOff);
		}
       
    }

}