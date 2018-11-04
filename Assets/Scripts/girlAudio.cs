using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 *AUDIO FILES
 * 0-Sniffling
 * 1-Can you help me
 * 2-I need to deliver
 * 3-Could you
 * 4-ACCEPT QUEST Oh good
 * 5-REJECT QUEST It's okay
 * 6-Oh Hey
 * 7-ACCEPT MUSHROOM QUEST 
 * 8-REJECT MUSHROOM QUEST
 * 
*/

public class girlAudio : MonoBehaviour {

	public AudioClip[] npcDialog;
	public AudioSource NPCSource;

	public Text NPCDialog;
	public bool returnToHelp = false;


	public GameObject deliveryQuestButton;
	public GameObject mushroomQuestButton;
	// Use this for initialization
	void Start () {
		//Start with Girl sniffling
		NPCSource.clip = npcDialog[0];
		NPCSource.Play ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider collider){
		if (!returnToHelp) {
			StartCoroutine(questGiven());
			deliveryQuestButton.gameObject.SetActive (true);
		} else {
			StartCoroutine(returnToGirl());
			mushroomQuestButton.gameObject.SetActive (true);
		}
		//Debug.Log ("Child Trigger enter hit");
	}

	void OnTriggerExit(Collider collider){
		NPCSource.clip = npcDialog[6];
		NPCSource.Play ();
		returnToHelp = true;
		//Debug.Log ("Child Trigger exit hit");
	}

	IEnumerator questGiven(){
		NPCSource.clip = npcDialog [0];
		NPCSource.Stop ();
		NPCSource.clip = npcDialog [1];
		NPCSource.Play ();
		NPCDialog.text = "Excuse me, can you help me?";
		yield return new WaitForSeconds (NPCSource.clip.length);
		NPCSource.clip = npcDialog [2];
		NPCSource.Play ();
		NPCDialog.text="I need to deliver a package to my grandmother, but I don't want to go into the woods.";
		yield return new WaitForSeconds (NPCSource.clip.length);
		NPCSource.clip = npcDialog [3];
		NPCSource.Play ();
		NPCDialog.text="Could you deliver the package for me?";

	}

	IEnumerator returnToGirl(){
		//ACCEPT
		NPCSource.clip = npcDialog [7];
		NPCSource.Play ();
		NPCDialog.text = "";
		//DECLINE
		yield return new WaitForSeconds (NPCSource.clip.length);
		NPCSource.clip = npcDialog [8];
		NPCSource.Play ();
		NPCDialog.text="";
	}


}
