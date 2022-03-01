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
	// defining number of poles and the frequency of motor.
	public float frequency = 60;
	public float poleNumber=4;
	
	
	// Control the activation of motor
	void MotorSystem(bool enableMotor,bool stateMotor,bool fixedAxis){
		var hinge = Axis.GetComponent<HingeJoint>();
		hinge.useMotor = enableMotor;
		motorIsOn = stateMotor;
		var AxisRigidbody = Axis.GetComponent<Rigidbody>();
		AxisRigidbody.freezeRotation = fixedAxis;
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
			MotorSystem(true,true,false);
			motorButtonRenderer.material.SetColor("_Color",colorOn);
			
			// targetVelocity make the hinge motor rotate with degrees per second
			// converting this for rad/s
			motor.targetVelocity = 6*120*frequency/poleNumber;
			//initial value of force of motor
			motor.force = 10000;
			motor.freeSpin = false;
			hinge.motor = motor;
			
		}
		else{
			MotorSystem(false,false,true);
			motorButtonRenderer.material.SetColor("_Color",colorOff);
		}
       
    }

}