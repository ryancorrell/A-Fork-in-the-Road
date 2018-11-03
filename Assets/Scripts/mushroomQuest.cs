using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mushroomQuest : MonoBehaviour {

	public bool deliveryQuestActive = false; 
	public Text deliveryScoreBoard;

	public bool mushroomQuestActive = false; 
	public Text mushroomScoreBoard;
	public GameObject mushroomParent;

	void Start(){
		deliveryScoreBoard.enabled = false;
		mushroomParent.gameObject.GetComponentInChildren<ParticleSystem> ().Stop();
		mushroomScoreBoard.enabled = false;
	}

	public void acceptDeliveryQuest(){
		//mushroomParent.gameObject.GetComponentInChildren<ParticleSystem> ().Play ();
		deliveryQuestActive = true; 
		deliveryScoreBoard.enabled = true;
	}

	public void acceptMushroomQuest(){
		//mushroomParent.gameObject.GetComponentInChildren<ParticleSystem> ().Play ();
		mushroomQuestActive = true; 
		mushroomParent.gameObject.GetComponentInChildren<ParticleSystem> ().Play();
		mushroomScoreBoard.enabled = true;
	}

}
