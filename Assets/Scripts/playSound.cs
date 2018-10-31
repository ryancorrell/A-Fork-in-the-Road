using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playSound : MonoBehaviour {

	public AudioClip voiceOver;
	public GameObject displayInstance;
	public bool isPlaying = false;

	void Start () {
		/*this.gameObject.AddComponent<AudioSource>();
		this.GetComponent<AudioSource>().clip = voiceOver;
*/
		displayInstance.AddComponent<AudioSource>();
		displayInstance.GetComponent<AudioSource>().clip = voiceOver;
	}

	public void onObjectClicked (){
		//Debug.Log ("onObjectClick was called");
		if (isPlaying == true) {
			displayInstance.GetComponent<AudioSource>().Stop();
			isPlaying = false;
		} else {
			displayInstance.GetComponent<AudioSource>().Play();
			isPlaying = true;
		}

	}
}


