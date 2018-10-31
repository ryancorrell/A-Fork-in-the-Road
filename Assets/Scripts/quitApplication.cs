using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quitApplication : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	void Update(){
		if (Input.GetKeyDown(KeyCode.Escape)) 
			Application.Quit(); 
	}
}
