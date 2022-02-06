using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotorControl : MonoBehaviour{

    public GameObject ButtonMotor;
    public bool motorIsOn;
	Color colorOn = Color.green;
	Color colorOff = Color.red;
	public GameObject Axis;
	
	
    void OnMouseDown(){ //THIS FUNCTION WILL DETECT THE MOUSE CLICK ON A COLLIDER,IN OUR CASE WILL DETECT THE CLICK ON THE BUTTON
		// Get the renderer from ButtonMotor
		var motorRenderer = ButtonMotor.GetComponent<Renderer>(); 
		var hinge = Axis.GetComponent<HingeJoint>();
		var motor = hinge.motor;
		var AxisRigidbody = Axis.GetComponent<Rigidbody>();
		AxisRigidbody.freezeRotation = true;
		
		if (motorIsOn == false){
			motorIsOn = true;
			motorRenderer.material.SetColor("_Color",colorOn);
			AxisRigidbody.freezeRotation = false;
			motor.force = 100;
			// Make the hinge motor rotate with 90 degrees per second and a strong force.
			motor.targetVelocity = 90;
			motor.freeSpin = false;
			hinge.motor = motor;
			hinge.useMotor = true;
			Debug.Log(hinge.velocity);
		}
		else{
			hinge.useMotor = false;
			motorIsOn = false;
			AxisRigidbody.freezeRotation = true;
			motorRenderer.material.SetColor("_Color",colorOff);
			Debug.Log(hinge.velocity);
		}
		

        
        
        
       
    }

}