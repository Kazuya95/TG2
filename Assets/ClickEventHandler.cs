// Script to activate event, in this case, to start the motor
// Put this script in the button.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickEventHandler : MonoBehaviour {

    public GameObject Door;
    public bool doorIsOpening;

    void Update () {
		
		//0 - left click; 1 - right click; 2 - middle click.
		/*if (Input.GetMouseButton(0))
        {
            Debug.Log("Pressed left click.");
			doorIsOpening = true;
        }*/
		
        if (doorIsOpening == true) {
            Door.transform.Translate(Vector3.up * Time.deltaTime * 10);
            //if the bool is true open the door
            
        }
        if (Door.transform.position.y > 4f) {
            doorIsOpening = false;
            //if the y of the door is > than 7 we want to stop the door
        }
		
		
    }
	
	// This function will detect the mouse click in the button.
    void OnMouseDown (){ 
        doorIsOpening = true;
        //if we click on the button door we must start to open
    }

}