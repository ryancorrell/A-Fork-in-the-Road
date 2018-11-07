using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forestAudio : MonoBehaviour {

	public AudioClip[] forestDialog;
	//public AudioSource forestSource;
	public GvrAudioSource forestSource;
	public GameObject trigger;

	private questLogic _questLogic;

/*	void Awake(){
		//Start with Forest Whispering - Range from 0-1
		int index = Random.Range(0, 1);
		//forestSource.clip = forestDialog[0];
		forestSource.clip = forestDialog[index];
		forestSource.Play ();
	}*/

	// Use this for initialization
	void Start () {

		//Get bool from questLogic to see if mushroom quest is active
		var mushroomQuestActiveCheck = GameObject.Find("GameLogic");
		if (mushroomQuestActiveCheck == null) {
			Debug.Log ("Could not find quest object");
			return;
		}
		_questLogic = mushroomQuestActiveCheck.GetComponent<questLogic>();
		if (_questLogic == null) {
			Debug.Log ("Could not find quest object");
		}


		//Start with Forest Whispering - Range from 0-1
		int index = Random.Range(0, 1);
		//forestSource.clip = forestDialog[0];
		forestSource.clip = forestDialog[index];
		forestSource.Play ();


	}

	// Update is called once per frame
	void Update () {
		//Check to see if quest is active
		if (_questLogic.mushroomQuestActive) {
			//Debug.Log ("Script successfully found!");
		}
	}

	void OnTriggerEnter(Collider collider){
		if (collider.tag == "Player") {
			forestSource.clip = forestDialog[2];
			forestSource.Play ();
		}
		Debug.Log ("Forest Trigger hit");

		if (_questLogic.mushroomQuestActive) {
			StartCoroutine(questActive());
		}else{
			StartCoroutine(questInactive());		
		}
	}

	IEnumerator questActive(){
		int index = Random.Range(0, 6);
		forestSource.clip = forestDialog[index];
		forestSource.Play ();
		yield return new WaitForSeconds (forestSource.clip.length);
	}

	IEnumerator questInactive(){
		int index = Random.Range(0, 4);
		forestSource.clip = forestDialog[index];
		forestSource.Play ();
		yield return new WaitForSeconds (forestSource.clip.length);
	}
}
