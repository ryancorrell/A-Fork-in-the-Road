using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundManagerForest : MonoBehaviour {

	private questLogic _questLogic;

	//public GameObject[] creepyForest; //Store clips in GameObjects
	public AudioClip[] creepyForest;

	//AudioSource assigned to each game object
	public GvrAudioSource whisper1;
	public GvrAudioSource whisper2;
	public GvrAudioSource forestDialog1;
	public GvrAudioSource forestDialog2;
	public GvrAudioSource forestDialog3;
	public GvrAudioSource forestDialog4;
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

		whisper1.clip = creepyForest [0];
		whisper1.Play ();

		whisper2.clip = creepyForest [1];
		whisper2.Play ();

		forestDialog1.clip = creepyForest [2];
		forestDialog1.Play ();

		forestDialog2.clip = creepyForest [3];
		forestDialog2.Play ();

		forestDialog3.clip = creepyForest [4];
		forestDialog3.Play ();

		forestDialog4.clip = creepyForest [5];
		forestDialog4.Play ();
		//Start with Forest Whispering - Range from 0-1
		//int index = Random.Range(0, 1);
		//forestSource.clip = forestDialog[0];
//		whisper1.clip = creepyForest[0].GetComponent<GvrAudioSource>();
//		forestSource.clip = forestDialog[index];
//		whisper1.Play ();

		//creepyForest [0].GetComponent<GvrAudioSource> ().clip;
		//creepyForest [0].GetComponent<GvrAudioSource> ().Play ();

	}

	// Update is called once per frame
	void Update () {
		
	}
}
