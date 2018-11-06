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
	//public AudioSource NPCSource;
	public GvrAudioSource NPCSource;

	public Text NPCDialog;
	public bool returnToHelp = false;
	public bool stopReturnPlay = false;

	public GameObject deliveryQuestButton;
	public GameObject deliveryQuestNoButton;
	public GameObject mushroomQuestButton;
	public GameObject mushroomQuestNoButton;

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
			deliveryQuestNoButton.gameObject.SetActive (true);
		} else {
			StartCoroutine(returnToGirl());
			mushroomQuestButton.gameObject.SetActive (true);
			mushroomQuestNoButton.gameObject.SetActive (true);
		}
		//Debug.Log ("Child Trigger enter hit");
	}

	void OnTriggerExit(Collider collider){
		if(!stopReturnPlay){
			NPCSource.clip = npcDialog[6];
			NPCSource.Play ();
			returnToHelp = true;
			//Debug.Log ("Child Trigger exit hit");
			stopReturnPlay = true;
		}
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
		NPCDialog.text = "Great! My grandmother really loves mushrooms. Can you find 5 mushrooms in the forest and give them to her?";
		yield return new WaitForSeconds (NPCSource.clip.length);
		NPCDialog.text = "";
	}

	IEnumerator rejectMushroomQuest(){
		//DECLINE
		NPCSource.clip = npcDialog [8];
		NPCSource.Play ();
		NPCDialog.text="That's okay. She rarely leaves her cottage much anymore. They're probably growning on her anyway.";
		yield return new WaitForSeconds (NPCSource.clip.length);
		NPCDialog.text = "";
	}
}
