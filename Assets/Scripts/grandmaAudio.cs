using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 *AUDIO FILES
 * 0-Door Knock
 * 1-Who is it
 * 2-Go away
 * 3-No loitering
 * 4-Well hello
 * 5-A package
 * 6-Here's a reward
 * 7-Mushroom! 
 * 8-Here's something
 * 9-And you brought me...
*/

public class grandmaAudio : MonoBehaviour {

	//Audio for Grandmother
	public AudioClip[] NPCGrandmaDialog;
	public GvrAudioSource NPCGrandmaSource;

	private questLogic _questLogic;

	public GameObject boxForGrandma;

	//REWARDS
	public GameObject moneyBag;
	public GameObject sodaCan;

	//End Game
	public endGame _endGame;

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

		moneyBag.SetActive (false);
		sodaCan.SetActive (false);

		_endGame = FindObjectOfType<endGame>();
			
	}
	
	// Update is called once per frame
	void Update () {
		if (_questLogic.mushroomQuestActive) {
			//Debug.Log ("Script successfully found!");
		}
	}

	public void goToGrandmothers(){
		//No active quests
		if (!_questLogic.deliveryQuestActive && !_questLogic.mushroomQuestActive && !_questLogic.mushroomQuestCompleted) {
			StartCoroutine (goAway ());
		//Delivery active, mushrooms inactive. OR Delivery active AND mushroom completed
		} else if (_questLogic.deliveryQuestActive && !_questLogic.mushroomQuestActive && !_questLogic.mushroomQuestCompleted || 
			_questLogic.deliveryQuestActive && !_questLogic.mushroomQuestActive && _questLogic.mushroomQuestCompleted) {
			StartCoroutine (deliverPackage ());
		//Delivery inactive and mushrooms active
		} else if (!_questLogic.deliveryQuestActive && _questLogic.mushroomQuestActive && _questLogic.mushroomQuestCompleted) {
			StartCoroutine (deliverMushrooms ());
		//Both active
		} else {
			StartCoroutine (deliverBoth ());
		}

	}

	public IEnumerator goAway(){
		//Door Knock
		NPCGrandmaSource.clip = NPCGrandmaDialog[0]; 
		NPCGrandmaSource.Play ();
		yield return new WaitForSeconds (NPCGrandmaSource.clip.length);
		NPCGrandmaSource.clip = NPCGrandmaDialog [1];
		NPCGrandmaSource.Play ();
		_questLogic.NPCDialog.text="Grandmother: Who is it? What do you want?";
		yield return new WaitForSeconds (NPCGrandmaSource.clip.length);
		NPCGrandmaSource.clip = NPCGrandmaDialog [2];
		NPCGrandmaSource.Play ();
		_questLogic.NPCDialog.text="Grandmother: Go Away!";
		yield return new WaitForSeconds (NPCGrandmaSource.clip.length);
		NPCGrandmaSource.clip = NPCGrandmaDialog [3];
		NPCGrandmaSource.Play ();
		_questLogic.NPCDialog.text="Grandmother: No loitering!";
		yield return new WaitForSeconds (5);
		_questLogic.NPCDialog.text="";
	}

	public IEnumerator deliverPackage(){
		//Door Knock
		NPCGrandmaSource.clip = NPCGrandmaDialog[0]; 
		NPCGrandmaSource.Play ();
		yield return new WaitForSeconds (NPCGrandmaSource.clip.length);
		NPCGrandmaSource.clip = NPCGrandmaDialog [4];
		NPCGrandmaSource.Play ();
		_questLogic.NPCDialog.text="Grandmother: Well hello dearie!";
		yield return new WaitForSeconds (NPCGrandmaSource.clip.length);
		NPCGrandmaSource.clip = NPCGrandmaDialog [5];
		NPCGrandmaSource.Play ();
		_questLogic.NPCDialog.text="Grandmother: A package from my granddaughter? Why thank you!";
		yield return new WaitForSeconds (NPCGrandmaSource.clip.length);
		Destroy (boxForGrandma);
		NPCGrandmaSource.clip = NPCGrandmaDialog [6];
		NPCGrandmaSource.Play ();
		_questLogic.NPCDialog.text="Grandmother: Here's a reward for your kindness.";
		yield return new WaitForSeconds (NPCGrandmaSource.clip.length);
		_questLogic.NPCDialog.text="";
		_questLogic.deliveryQuestActive = false; 
		_questLogic.deliveryQuestInactive = true;
		sodaCan.SetActive (true);
	}

	IEnumerator deliverMushrooms(){
		//Door Knock
		NPCGrandmaSource.clip = NPCGrandmaDialog[0]; 
		NPCGrandmaSource.Play ();
		yield return new WaitForSeconds (NPCGrandmaSource.clip.length);
		NPCGrandmaSource.clip = NPCGrandmaDialog [7];
		NPCGrandmaSource.Play ();
		_questLogic.NPCDialog.text="Grandmother: Mushrooms! My favorite!";
		Destroy (_questLogic.mushroomIcon);
		Destroy (_questLogic.mushroomScoreBoard);
		yield return new WaitForSeconds (NPCGrandmaSource.clip.length);
		NPCGrandmaSource.clip = NPCGrandmaDialog [8];
		NPCGrandmaSource.Play ();
		_questLogic.NPCDialog.text="Grandmother: Here's something for your troubles.";
		yield return new WaitForSeconds (NPCGrandmaSource.clip.length);
		_questLogic.NPCDialog.text="";
		_questLogic.mushroomQuestActive = false;
		_questLogic.mushroomQuestInactive = true;
		_questLogic.mushroomQuestCompleted = true;
		moneyBag.SetActive (true);
	}

	IEnumerator deliverBoth(){
		//Door Knock
		NPCGrandmaSource.clip = NPCGrandmaDialog[0]; 
		NPCGrandmaSource.Play ();
		yield return new WaitForSeconds (NPCGrandmaSource.clip.length);	
		NPCGrandmaSource.clip = NPCGrandmaDialog [4];
		NPCGrandmaSource.Play ();
		_questLogic.NPCDialog.text="Grandmother: Well hello dearie!";
		yield return new WaitForSeconds (NPCGrandmaSource.clip.length);
		NPCGrandmaSource.clip = NPCGrandmaDialog [5];
		NPCGrandmaSource.Play ();
		_questLogic.NPCDialog.text="Grandmother: A package from my granddaughter? Why thank you!";
		yield return new WaitForSeconds (NPCGrandmaSource.clip.length);
		Destroy (boxForGrandma);
		NPCGrandmaSource.clip = NPCGrandmaDialog [9];
		NPCGrandmaSource.Play ();
		_questLogic.NPCDialog.text="Grandmother: And you brought me mushrooms! My favorite!";
		Destroy (_questLogic.mushroomIcon);
		Destroy (_questLogic.mushroomScoreBoard);

		yield return new WaitForSeconds (NPCGrandmaSource.clip.length);
		NPCGrandmaSource.clip = NPCGrandmaDialog [8];
		NPCGrandmaSource.Play ();
		_questLogic.NPCDialog.text="Grandmother: Here's something for your troubles.";
		yield return new WaitForSeconds (NPCGrandmaSource.clip.length);
		_questLogic.NPCDialog.text="";
		_questLogic.deliveryQuestActive = false; 
		_questLogic.mushroomQuestActive = false;
		_questLogic.deliveryQuestInactive = true;
		_questLogic.mushroomQuestInactive = true;
		moneyBag.SetActive (true);
		yield return new WaitForSeconds (3);
		_endGame.FadeToEnd ();
	}
}
