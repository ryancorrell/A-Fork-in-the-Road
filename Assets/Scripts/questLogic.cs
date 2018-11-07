using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class questLogic : MonoBehaviour {

	public bool deliveryQuestActive = false; 
	public Text deliveryScoreBoard;

	public bool mushroomQuestActive = false; 
	public Text mushroomScoreBoard;
	public GameObject mushroomParent;
	public Text NPCDialog;

	public GameObject deliveryQuestButton;
	public GameObject deliveryQuestNoButton;
	public GameObject mushroomQuestButton;
	public GameObject mushroomQuestNoButton;

	//Particle System array from childen of MushroomParent
	ParticleSystem[] childrenParticleSystem;

	//public GameObject tmpGirl;


	void Start(){
		//When game starts, the scoreboard is blank
		deliveryScoreBoard.enabled = false;
		mushroomScoreBoard.enabled = false;
		//NPCDialog.enabled = false;

		//assign particles
		childrenParticleSystem = mushroomParent.gameObject.GetComponentsInChildren<ParticleSystem> ();
		//childrenParticleSystem = gameObject.GetComponentsInChildren<ParticleSystem> ();

		//All quest buttons are off
		deliveryQuestButton.gameObject.SetActive(false);
		deliveryQuestNoButton.gameObject.SetActive(false);
		mushroomQuestButton.gameObject.SetActive(false);
		mushroomQuestNoButton.gameObject.SetActive(false);

	}

	void Update(){

		if (!mushroomQuestActive) {
			foreach (ParticleSystem childPS in childrenParticleSystem) {
				ParticleSystem.EmissionModule childPSEmissionModule = childPS.emission;
				childPSEmissionModule.enabled = false;
			}

			//mushroomQuestActive = true;

		}

	}

	public void acceptDeliveryQuest(){
		//mushroomParent.gameObject.GetComponentInChildren<ParticleSystem> ().Play ();
		deliveryQuestActive = true; 
		deliveryScoreBoard.enabled = true;
		deliveryQuestButton.gameObject.SetActive (false);
		deliveryQuestNoButton.gameObject.SetActive (false);
		//NPCDialog.text = "Oh good! Thank you!";
	}

	public void rejectDeliveryQuest(){
		//mushroomParent.gameObject.GetComponentInChildren<ParticleSystem> ().Play ();
		deliveryQuestActive = false; 
		//deliveryScoreBoard.enabled = true;
		deliveryQuestButton.gameObject.SetActive (false);
		deliveryQuestNoButton.gameObject.SetActive (false);
		NPCDialog.text = "Oh. It's okay. I hope to find someone else to deliver the package before it gets dark.";
	}

	public void acceptMushroomQuest(){
		//mushroomParent.gameObject.GetComponentInChildren<ParticleSystem> ().Play ();
		mushroomQuestActive = true; 
		//mushroomParent.gameObject.GetComponentInChildren<ParticleSystem> ().Play();
		foreach (ParticleSystem childPS in childrenParticleSystem) {
			ParticleSystem.EmissionModule childPSEmissionModule = childPS.emission;
			childPSEmissionModule.enabled = true;
		}
		mushroomScoreBoard.enabled = true;
		mushroomQuestButton.gameObject.SetActive (false);
		mushroomQuestNoButton.gameObject.SetActive (false);
		//NPCDialog.text = "Great! My grandmother really loves mushrooms. Can you find 5 mushrooms in the forest and give them to her?";
		Debug.Log ("Accepted");
	}

	public void rejectMushroomQuest(){
		mushroomQuestActive = false; 
		mushroomScoreBoard.enabled = true;
		mushroomQuestButton.gameObject.SetActive (false);
		mushroomQuestNoButton.gameObject.SetActive (false);
		//NPCDialog.text = "Great! My grandmother really loves mushrooms. Can you find 5 mushrooms in the forest and give them to her?";
		Debug.Log ("Rejected");
	}

}
