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
	public static int mushroomTotal = 0;

	public AudioClip[] tingClip;
	public GvrAudioSource audioSource;

	ParticleSystem[] childrenParticleSystem;

	// Use this for initialization
	void Start() {
		mushroomTotal = 0;
		childrenParticleSystem = mushroomParent.gameObject.GetComponentsInChildren<ParticleSystem> ();
		//Start with quest board hidden
		//mushroomParent.gameObject.GetComponentInChildren<ParticleSystem> ().Stop();
		mushroomScoreBoard.enabled = false;
	}

	// Update is called once per frame
	void Update() {

	}
		
	public void pickMushroom(){
		//questLog.Text = "";
		mushroomTotal ++;
		mushroomScoreBoard.text = "Mushrooms collected: " + mushroomTotal + "/5";
		audioSource.clip = tingClip[0];
		audioSource.Play ();
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
			audioSource.clip = tingClip[1];
			audioSource.Play ();
			mushroomScoreBoard.text = "All mushrooms collected!";
			//mushroomParent.gameObject.GetComponentInChildren<ParticleSystem> ().Stop();
			foreach (ParticleSystem childPS in childrenParticleSystem) {
				ParticleSystem.EmissionModule childPSEmissionModule = childPS.emission;
				childPSEmissionModule.enabled = false;
			}
		}
	}


}
