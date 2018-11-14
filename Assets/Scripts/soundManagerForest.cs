using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundManagerForest : MonoBehaviour {

	private questLogic _questLogic;

	//public GameObject[] creepyForest; //Store clips in GameObjects
	public AudioClip[] creepyForest;

	//AudioSource assigned to each game object
	public GvrAudioSource whisper0;
	public GvrAudioSource whisper1;
	public GvrAudioSource forestDialog2;
	public GvrAudioSource forestDialog3;
	public GvrAudioSource forestDialog4;
	public GvrAudioSource forestDialog5;
	public GvrAudioSource backgroundSounds6;
	/*AudioSource Array
	 * whispers1
	 * whispers2
	 * forest dialog
	 * forest dialog
	 * spooky sounds
	 */


	/*		
		GvrAudioSource.clip = AudioClip[];
		GvrAudioSource.Play();
	*/

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

		//whispers always playing - ALT TURN LOOPING ON THOSE
		whisper0.clip = creepyForest [0];
		whisper0.Play ();

		whisper1.clip = creepyForest [1];
		whisper1.Play ();
	
	}

	// Update is called once per frame
	void Update () {
		
	}

/*	void OnTriggerEnter(Collider collider){
		Debug.Log ("Forest Trigger hit");

		if (_questLogic.mushroomQuestActive) {
			StartCoroutine(questActive());
		}else{
			StartCoroutine(questInactive());		
		}
		forestDialog5.clip = creepyForest [5];
		forestDialog5.Play ();
	}*/

	public IEnumerator questActive(){
		/*
			What does it want?
			It takes our mushrooms
			What is it?
			Give them back!
		*/
		yield return new WaitForSeconds (2.5f);
		forestDialog2.clip = creepyForest [2];
		forestDialog2.Play ();
		yield return new WaitForSeconds (2.5f);
		forestDialog3.clip = creepyForest [3];
		forestDialog3.Play ();
		yield return new WaitForSeconds (2.5f);
		forestDialog4.clip = creepyForest [4];
		forestDialog4.Play ();
		yield return new WaitForSeconds (2.5f);
	}

	public IEnumerator questInactive(){
		/*
			What does it want?
			What is it?
		*/
		yield return new WaitForSeconds (2.5f);
		forestDialog2.clip = creepyForest [2];
		forestDialog2.Play ();
		yield return new WaitForSeconds (2.75f);
		forestDialog5.clip = creepyForest [5];
		forestDialog5.Play ();
		yield return new WaitForSeconds (2.5f);
	}
}
