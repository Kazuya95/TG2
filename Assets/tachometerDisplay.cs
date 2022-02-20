using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tachometerDisplay : MonoBehaviour
{
    //to read data
	void Update(){
		// repeat the read of velocity data
		StartCoroutine(ReadAxisVelocity());
	}
	
	// Coroutine to wait 15s to show velocity of axis
	IEnumerator ReadAxisVelocity(){
		var hinge = GameObject.Find("Axis").GetComponent<HingeJoint>();
        //Print the time of when the function is first called.
		// variable to read current velocity in degrees/s (standard for the programming in the Unity)
		//is converted to rad/s and rounding to 2 decimal places
		var statusVelocityRadS = (Mathf.PI*hinge.velocity/180).ToString("#0.00");
		//to show from degree/s to RPM
		var statusVelocityRPM = (hinge.velocity/6).ToString("#0.00");
		TextMesh textObject = GameObject.Find("velocitydisplay").GetComponent<TextMesh>();
		var messageVelocity = string.Format("{0} rad/s \n{1}RPM",statusVelocityRadS,statusVelocityRPM) ;
		textObject.text = messageVelocity;

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(10);
    }
	
	
}
