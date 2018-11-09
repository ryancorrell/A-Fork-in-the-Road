using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mushroomsCollected : MonoBehaviour {
	//public bool gameEnded = false;
	//public bool playerWon = false;

	//public GameObject questLog;
	//public GameObject restartPanel;
	public GameObject mushroom;
	public GameObject mushroomParent;
	public Text mushroomScoreBoard;
	public bool mushroomQuestCompleted = false;
	public static int mushroomTotal = 0;

	public AudioClip[] tingClip;
	public GvrAudioSource audioSource;

	private questLogic _questLogic;

	// Use this for initialization
	void Start() {
		mushroomTotal = 0;
		//Start with quest board hidden
		mushroomScoreBoard.enabled = false;

		toggleActiveMushrooms (false);

		//enable questLogic
		var mushroomQuestCompleted = GameObject.Find("GameLogic");
		if (mushroomQuestCompleted == null) {
			Debug.Log ("Could not find quest object");
			return;
		}
		_questLogic = mushroomQuestCompleted.GetComponent<questLogic>();
		if (_questLogic == null) {
			Debug.Log ("Could not find quest object");
		}


	}

	// Update is called once per frame
	void Update() {
		if (_questLogic.mushroomQuestActive == true && _questLogic.mushroomQuestCompleted == false) {
			toggleActiveMushrooms (true);
		} else {
			toggleActiveMushrooms (false);
		}
	}
		
	public void toggleActiveMushrooms(bool toggle){
		GetComponent<Collider> ().enabled = toggle;
		GetComponent<GvrPointerPhysicsRaycaster> ().enabled = toggle;
		GetComponent<SphereCollider> ().enabled = toggle;
	}

	public void pickMushroom(){
		//questLog.Text = "";
		mushroomTotal ++;
		mushroomScoreBoard.text = "Mushrooms collected: " + mushroomTotal + "/5";
		//audioSource.clip = tingClip[0];
		audioSource.PlayOneShot (tingClip[0], .9f);
		Debug.Log("Total Mushrooms picked: " + mushroomTotal);
		Destroy (mushroom, .5f);
		checkForCompletion ();
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

	public void checkForCompletion() {
		if (mushroomTotal == 5) {
			//audioSource.clip = tingClip[1];
			audioSource.PlayOneShot (tingClip[1], .9f);
			mushroomScoreBoard.text = "All mushrooms collected!";
			mushroomQuestCompleted = true;
			_questLogic.mushroomQuestCompleted = true;
			_questLogic.mushroomQuestActive = false;
			//Disable all mushrooms
			toggleActiveMushrooms (false);
		}
	}


}
