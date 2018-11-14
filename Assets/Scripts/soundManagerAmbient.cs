using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundManagerAmbient : MonoBehaviour {

	//private questLogic _questLogic;

	public AudioClip[] goodForest;

	//AudioSource assigned to each game object
	public GvrAudioSource ambientSound;

	/*		
		GvrAudioSource.clip = AudioClip[];
		GvrAudioSource.Play();
	*/

	// Use this for initialization
	void Start () {
		ambientSound.clip = goodForest [0];
		ambientSound.Play ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}



}
