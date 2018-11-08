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
*/

public class girlAudio : MonoBehaviour {

	public AudioClip[] npcDialog;
	public GvrAudioSource NPCSource;

	public Text NPCDialog;
	public bool returnToHelp = false;
	public bool stopReturnPlay = true;

	public GameObject deliveryQuestButton;
	public GameObject deliveryQuestNoButton;
	public GameObject mushroomQuestButton;
	public GameObject mushroomQuestNoButton;

	//public Transform player;

	// Use this for initialization
	void Start () {

		//Start with Girl sniffling
		NPCSource.clip = npcDialog[0];
		NPCSource.Play ();

		//player = GameObject.FindGameObjectWithTag ("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {	

	}

	void OnTriggerEnter(Collider collider){
		if (!returnToHelp) {
			StartCoroutine(questGiven());
			deliveryQuestButton.gameObject.SetActive (true);
			deliveryQuestNoButton.gameObject.SetActive (true);
			stopReturnPlay = false;
		} else {
			StartCoroutine(returnToGirl());
			mushroomQuestButton.gameObject.SetActive (true);
			mushroomQuestNoButton.gameObject.SetActive (true);
			stopReturnPlay = true;
		}
		//Debug.Log ("Child Trigger enter hit");
	}

	void OnTriggerExit(Collider collider){
		if(!stopReturnPlay){
			StartCoroutine (comeBack ());
		}
	}

	public void acceptDeliveryQuestDialog(){
		StartCoroutine (acceptDeliveryQuestCoroutine ());
	}

	public void rejectDeliveryQuestDialog(){
		StartCoroutine (rejectDeliveryQuestCoroutine ());
	}

	public void acceptMushroomQuestDialog(){
		StartCoroutine (acceptMushroomQuestCoroutine ());
	}

	public void rejectMushroomQuestDialog(){
		StartCoroutine (rejectMushroomQuestCoroutine ());
	}

	public IEnumerator acceptDeliveryQuestCoroutine(){
		NPCSource.clip = npcDialog [4];
		NPCSource.Play ();
		NPCDialog.text = "Oh good! Thank you!";
		yield return new WaitForSeconds (NPCSource.clip.length);
		NPCDialog.text = "";
	}

	public IEnumerator rejectDeliveryQuestCoroutine(){
		//DECLINE
		NPCSource.clip = npcDialog [5];
		NPCSource.Play ();
		NPCDialog.text="Oh. It's okay. I hope to find someone else to deliver the package before it gets dark.";
		yield return new WaitForSeconds (NPCSource.clip.length);
		NPCDialog.text = "";
	}

	public IEnumerator acceptMushroomQuestCoroutine(){
		NPCSource.clip = npcDialog [4];
		NPCSource.Play ();
		NPCDialog.text = "Oh good! Thank you!";
		yield return new WaitForSeconds (NPCSource.clip.length);
		NPCDialog.text = "";
	}

	public IEnumerator rejectMushroomQuestCoroutine(){
		//DECLINE
		NPCSource.clip = npcDialog [8];
		NPCSource.Play ();
		NPCDialog.text="That's okay. She rarely leaves her cottage much anymore. They're probably growning on her anyway.";
		yield return new WaitForSeconds (NPCSource.clip.length);
		NPCDialog.text = "";
	}

	public IEnumerator questGiven(){
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
		yield return new WaitForSeconds (2);
		NPCDialog.text="";
	}

	public IEnumerator comeBack(){
		returnToHelp = true;
		stopReturnPlay = true;
		NPCSource.clip = npcDialog [6];
		NPCSource.Play ();
		NPCDialog.text = "Oh hey! Can you do one more thing for me?";
		yield return new WaitForSeconds (NPCSource.clip.length);
		NPCDialog.text = "";
	}

	public IEnumerator returnToGirl(){
		//ACCEPT
		NPCSource.clip = npcDialog [7];
		NPCSource.Play ();
		NPCDialog.text = "Great! My grandmother really loves mushrooms. Can you find 5 mushrooms in the forest and give them to her?";
		yield return new WaitForSeconds (NPCSource.clip.length);
		NPCDialog.text = "";
		stopReturnPlay = true;
	}
		
}
