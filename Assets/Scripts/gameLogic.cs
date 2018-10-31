using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameLogic : MonoBehaviour {

	public GameObject player;
	public GameObject eventSystem;
	public GameObject startUI, restartUI;
	public GameObject startPoint, restartPoint;

	// Use this for initialization
	void Start () {
		//Start position for the player
		player = player.transform.parent.gameObject;	

		//Move player to start position
		player.transform.position = startPoint.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void	questSuccess(){
	
	}

	public void questFailure(){

	}
}
