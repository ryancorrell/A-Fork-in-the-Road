using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forestTrigger : MonoBehaviour {

	private questLogic _questLogic;
	private soundManagerForest _forestSounds;
	public Collider thisOne;

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


		var forestSoundCheck = GameObject.Find("SoundManagerForest");
		if (forestSoundCheck == null) {
			Debug.Log ("Could not find sound object");
			return;
		}
		_forestSounds = forestSoundCheck.GetComponent<soundManagerForest> ();
		if (_forestSounds == null) {
			Debug.Log ("Could not find quest object");
		}

	}
	
	void OnTriggerEnter(Collider collider){
		Debug.Log ("Forest Trigger hit");

		if (_questLogic.mushroomQuestActive) {
			StartCoroutine(_forestSounds.gameObject.GetComponent<soundManagerForest> ().questActive ());
		}else{
			StartCoroutine(_forestSounds.gameObject.GetComponent<soundManagerForest> ().questInactive());
		}
		_forestSounds.forestDialog5.clip = _forestSounds.creepyForest [5];
		_forestSounds.forestDialog5.Play ();
	}
}
