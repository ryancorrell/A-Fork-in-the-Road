﻿using System.Collections;
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

	ParticleSystem[] childrenParticleSystem;

	void Start(){
		deliveryScoreBoard.enabled = false;
		mushroomScoreBoard.enabled = false;
		childrenParticleSystem = gameObject.GetComponentsInChildren<ParticleSystem> ();
	}

	void Update(){

		if (!mushroomQuestActive) {
			foreach (ParticleSystem childPS in childrenParticleSystem) {
				ParticleSystem.EmissionModule childPSEmissionModule = childPS.emission;
				childPSEmissionModule.enabled = false;
			}

			mushroomQuestActive = true;

		}

	}

	public void acceptDeliveryQuest(){
		//mushroomParent.gameObject.GetComponentInChildren<ParticleSystem> ().Play ();
		deliveryQuestActive = true; 
		deliveryScoreBoard.enabled = true;
	}

	public void acceptMushroomQuest(){
		//mushroomParent.gameObject.GetComponentInChildren<ParticleSystem> ().Play ();
		mushroomQuestActive = true; 
		//mushroomParent.gameObject.GetComponentInChildren<ParticleSystem> ().Play();
		//foreach (ParticleSystem childParticleSystem in children) {
		//	childParticleSystem.Play ();
		//}
		mushroomScoreBoard.enabled = true;
	}

}