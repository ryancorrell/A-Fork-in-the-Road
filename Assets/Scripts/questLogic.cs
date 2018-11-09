using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class questLogic : MonoBehaviour {

	public bool deliveryQuestActive = false;
	public bool deliveryQuestInactive = false;
	public Text deliveryScoreBoard;

	public bool mushroomQuestActive = false; 
	public bool mushroomQuestInactive = false;
	public bool mushroomQuestCompleted = false;
	public Text mushroomScoreBoard;
	public GameObject mushroomParent;
	public Text NPCDialog;

	public GameObject deliveryQuestButton;
	public GameObject deliveryQuestNoButton;
	public GameObject mushroomQuestButton;
	public GameObject mushroomQuestNoButton;

	public girlAudio _girlAudio;
	public mushroomsCollected _mushrooms;

	void Start(){
		//When game starts, the scoreboard is blank
		deliveryScoreBoard.enabled = false;
		mushroomScoreBoard.enabled = false;
		//NPCDialog.enabled = false;

		//All quest buttons are off
		deliveryQuestButton.gameObject.SetActive(false);
		deliveryQuestNoButton.gameObject.SetActive(false);
		mushroomQuestButton.gameObject.SetActive(false);
		mushroomQuestNoButton.gameObject.SetActive(false);
	}

	void Update(){

	}

	public void acceptDeliveryQuest(){
		//mushroomParent.gameObject.GetComponentInChildren<ParticleSystem> ().Play ();
		deliveryQuestActive = true; 
		deliveryScoreBoard.enabled = true;
		deliveryQuestButton.gameObject.SetActive (false);
		deliveryQuestNoButton.gameObject.SetActive (false);
		_girlAudio.acceptDeliveryQuestDialog ();
	}

	public void rejectDeliveryQuest(){
		//mushroomParent.gameObject.GetComponentInChildren<ParticleSystem> ().Play ();
		deliveryQuestActive = false; 
		deliveryScoreBoard.enabled = false;
		deliveryQuestButton.gameObject.SetActive (false);
		deliveryQuestNoButton.gameObject.SetActive (false);
		_girlAudio.rejectDeliveryQuestDialog ();
	}

	public void acceptMushroomQuest(){
		//mushroomParent.gameObject.GetComponentInChildren<ParticleSystem> ().Play ();
		mushroomQuestActive = true;
		mushroomScoreBoard.enabled = true;
		mushroomQuestButton.gameObject.SetActive (false);
		mushroomQuestNoButton.gameObject.SetActive (false);
		_girlAudio.acceptMushroomQuestDialog();
		//Debug.Log ("Accepted");

	}

	public void rejectMushroomQuest(){
		mushroomQuestActive = false; 
		mushroomScoreBoard.enabled = false;
		mushroomQuestButton.gameObject.SetActive (false);
		mushroomQuestNoButton.gameObject.SetActive (false);
		_girlAudio.rejectMushroomQuestDialog();
		Debug.Log ("Rejected");
	}

}
