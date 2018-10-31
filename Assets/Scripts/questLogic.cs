using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class questLogic : MonoBehaviour {
	//public bool gameEnded = false;
	//public bool playerWon = false;
	public bool mushroomQuestActive = false;

	//public GameObject questLog;
	//public GameObject restartPanel;
	public GameObject mushrooms;
	private ParticleSystem ps;
	public bool particlesEnabled;
	public int mushroomTotal = 0;

	//public Text restartText;
	

	// Use this for initialization
	void Start() {
		ps = GetComponent<ParticleSystem> ();

	}

	// Update is called once per frame
	void Update() {
		if (mushroomQuestActive == true) {
			var emission = ps.emission;
			emission.enabled = particlesEnabled;
		}
	
		
	}


	void OnGUI(){
		particlesEnabled = GUI.Toggle (new Rect (25, 45, 100, 30), particlesEnabled, "Enabled");
	}

	public void pickMushroom(){
		//questLog.Text = "";
		mushroomTotal += 1;
		Debug.Log("Total Mushrooms picked: " + mushroomTotal);
		particlesEnabled = GUI.Toggle (new Rect (25, 45, 100, 30), particlesEnabled, "Disabled");
	}

	//public void gameOver() {
		//Display victory or defeat message
		//Give the player the chance to play again
	//	gameEnded = true;

	//	restartPanel.SetActive(true);

	//}

	//public void newGame() {
	//	gameEnded = false;
	//	playerWon = false;
	//	restartPanel.SetActive(false);

	//}

	public void checkForVictory() {

	}


}
