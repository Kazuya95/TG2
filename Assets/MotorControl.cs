using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MotorControl : MonoBehaviour{

    public GameObject ButtonMotor;
    public bool motorIsOn;
	Color colorOn = Color.green;
	Color colorOff = Color.red;
	public GameObject Axis;
	public GameObject Switch;
	public float velocity;
	
	
	void Update(){

		var hinge = Axis.GetComponent<HingeJoint>();
		// variable to read current velocity in degrees/s
		string statusVelocity = string.Format("current degrees/s: {0}.",hinge.velocity);
		Debug.Log(statusVelocity);
	}
	
	
    void OnMouseDown(){ //THIS FUNCTION WILL DETECT THE MOUSE CLICK ON A COLLIDER,IN OUR CASE WILL DETECT THE CLICK ON THE BUTTON
		// Get the renderer from ButtonMotor
		var motorButtonRenderer = ButtonMotor.GetComponent<Renderer>(); 
		var hinge = Axis.GetComponent<HingeJoint>();
		var motor = hinge.motor;
		var AxisRigidbody = Axis.GetComponent<Rigidbody>();
		AxisRigidbody.freezeRotation = true;
		var switchAction = Switch.GetComponent<Switch_action>();
		var switchState = switchAction.switchIsOn;
		
		if (motorIsOn == false && switchState==true){
			motorIsOn = true;
			motorButtonRenderer.material.SetColor("_Color",colorOn);
			AxisRigidbody.freezeRotation = false;
			motor.force = 100*10000;
			// targetVelocity make the hinge motor rotate with degrees per second
			// adapting this for rad/s
			motor.targetVelocity = 3600;
			motor.freeSpin = false;
			hinge.motor = motor;
			hinge.useMotor = true;
		}
		else{
			hinge.useMotor = false;
			motorIsOn = false;
			AxisRigidbody.freezeRotation = true;
			motorButtonRenderer.material.SetColor("_Color",colorOff);
		}
		
           
       
    }

}