//Script to control camera and small menu (for tools and reports)

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	// camera parameters
	// limitations of view angle
	public float minimumX = -60f;
	public float maximumX = 60f;
	public float minimumY = -360f;
	public float maximumY = 360f;
	
	//adjustable sensitivity
	public float sensitivityX = 100f;
	public float sensitivityY = 100f;
	
	// reference of used camera (search for 'Tag')
	public Camera MainCamera;
	
	//current rotation in X and Y axis
	float rotationY = 0f;
	float rotationX = 0f;
	
	//parameters for drag function
	private Vector3 mOffset;
    private float mZCoord;
	
	//configure the field of view in the beginning
    void Start()
	{
		Camera.main.fieldOfView = 40f;
	}
	
	
    void Update()
    {
		// => Change this to follow smartphone giroscopy 
		// set the desired rotation angle around the Y-axis
        rotationY += Input.GetAxis("Mouse X") * sensitivityY;
		rotationX += Input.GetAxis("Mouse Y") * sensitivityX;
		// to constrain the desired rotation values to their maximum and minimum values
		rotationX = Mathf.Clamp(rotationX,minimumX,maximumX);
		
		//player body rotate only around Y-axis
		transform.localEulerAngles = new Vector3(0,rotationY,0);
		//camera rotation
		MainCamera.transform.localEulerAngles = new Vector3(-rotationX,rotationY,0);
		
		if (Input.GetMouseButton(1))
    {
        Debug.Log("Pressed right click.");
    }
    }
	
	
}

