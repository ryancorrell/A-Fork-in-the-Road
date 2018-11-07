using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grandmaAudio : MonoBehaviour {

	//Audio for Grandmother
	public AudioClip[] npcDialog;
	//public AudioSource NPCSource;
	public GvrAudioSource NPCSource;

	private questLogic _questLogic;

	// Use this for initialization
	void Start () {
		//Get bool from questLogic to see if which quests are active
		var mushroomQuestActiveCheck = GameObject.Find("GameLogic");
		if (mushroomQuestActiveCheck == null) {
			Debug.Log ("Could not find quest object");
			return;
		}
		_questLogic = mushroomQuestActiveCheck.GetComponent<questLogic>();
		if (_questLogic == null) {
			Debug.Log ("Could not find quest object");
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (_questLogic.mushroomQuestActive) {
			//Debug.Log ("Script successfully found!");
		}
	}

	public void goToGrandmothers(){
		//Door Knock
		//NPCSource.clip = npcDialog[0]; 
		//NPCSource.Play ();
		if (!_questLogic.deliveryQuestActive && !_questLogic.mushroomQuestActive) {
			StartCoroutine (goAway ());
		} else if (_questLogic.deliveryQuestActive && !_questLogic.mushroomQuestActive) {
			StartCoroutine (deliverPackage ());
		} else if (!_questLogic.deliveryQuestActive && _questLogic.mushroomQuestActive) {
			StartCoroutine (deliverMushrooms ());
		} else {
			StartCoroutine (deliverBoth ());
		}

	}

	IEnumerator goAway(){
		//NPCSource.clip = npcDialog [2];
		//NPCSource.Play ();
		_questLogic.NPCDialog.text="Who is it? What do you want?";
		yield return new WaitForSeconds (5);
		_questLogic.NPCDialog.text="Go Away!";
		yield return new WaitForSeconds (5);
		//yield return new WaitForSeconds (NPCSource.clip.length);
		//NPCSource.clip = npcDialog [3];
		//NPCSource.Play ();
		_questLogic.NPCDialog.text="No loitering!";
		yield return new WaitForSeconds (5);
		_questLogic.NPCDialog.text="";
	}

	IEnumerator deliverPackage(){
		//NPCSource.clip = npcDialog [2];
		//NPCSource.Play ();
		_questLogic.NPCDialog.text="Well hello dearie!";
		yield return new WaitForSeconds (5);
		_questLogic.NPCDialog.text="A package from my granddaughter? Why thank you!";
		yield return new WaitForSeconds (5);
		_questLogic.NPCDialog.text="Here's a reward for your kindness.";
		yield return new WaitForSeconds (5);
		_questLogic.NPCDialog.text="";
		_questLogic.deliveryQuestActive = false; 
	}

	IEnumerator deliverMushrooms(){
		//NPCSource.clip = npcDialog [2];
		//NPCSource.Play ();
		_questLogic.NPCDialog.text="Mushrooms! My favorite!";
		yield return new WaitForSeconds (5);
		_questLogic.NPCDialog.text="Here's something for your troubles.";
		yield return new WaitForSeconds (5);
		_questLogic.NPCDialog.text="";
		_questLogic.mushroomQuestActive = false;
	}

	IEnumerator deliverBoth(){
		//NPCSource.clip = npcDialog [2];
		//NPCSource.Play ();
		_questLogic.NPCDialog.text="Well hello dearie!";
		yield return new WaitForSeconds (5);
		_questLogic.NPCDialog.text="A package from my granddaughter? Why thank you!";
		yield return new WaitForSeconds (5);
		_questLogic.NPCDialog.text="And you brought me mushrooms! My favorite!";
		yield return new WaitForSeconds (5);
		_questLogic.NPCDialog.text="Here's something for your troubles.";
		yield return new WaitForSeconds (5);
		_questLogic.NPCDialog.text="";
		_questLogic.deliveryQuestActive = false; 
		_questLogic.mushroomQuestActive = false;
	}
}
