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
	
	//to read data
	void Update(){
		// repeat the read of velocity data
		StartCoroutine(ReadAxisVelocity());
	}
	
	// Coroutine to wait 15s to show velocity of axis
	IEnumerator ReadAxisVelocity(){
		var hinge = Axis.GetComponent<HingeJoint>();
        //Print the time of when the function is first called.
		// variable to read current velocity in degrees/s (standard for the programming in the Unity)
		//is converted to rad/s and rounding to 2 decimal places
		var statusVelocityRadS = (Mathf.PI*hinge.velocity/180).ToString("#.00");
		//to show from degree/s to RPM
		var statusVelocityRPM = (hinge.velocity/6).ToString("#.00");
		Debug.Log("current angular velocity [rad/s]: " + statusVelocityRadS);
		Debug.Log("current angular velocity [RPM]: " + statusVelocityRPM);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(15);
    }
	
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
			motor.force = 100*10000;
			// targetVelocity make the hinge motor rotate with degrees per second
			// adapting this for rad/s
			motor.targetVelocity = 3600;
			motor.freeSpin = false;
			hinge.motor = motor;
		}
		else{
			MotorSystem(false,false,true);
			motorButtonRenderer.material.SetColor("_Color",colorOff);
		}
       
    }

}