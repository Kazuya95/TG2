using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class form : MonoBehaviour
{

	public GameObject formScreen;
	private bool enabledForm = false;

	
	//void Start(){
	//}
	
    void OnMouseDown(){
		if (enabledForm == false){
			formScreen.SetActive(true);
		}
		else {
			formScreen.SetActive(false);
		}
		
	}
}
