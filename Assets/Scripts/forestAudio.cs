using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forestAudio : MonoBehaviour {

	public AudioClip[] forestDialog;
	public AudioSource forestSource;
	public GameObject trigger;

	// Use this for initialization
	void Start () {
		//Start with Forest Whispering - Range from 0-1
		int index = Random.Range(0, 1);
		//forestSource.clip = forestDialog[0];
		forestSource.clip = forestDialog[index];
		forestSource.Play ();
	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider collider){
		if (collider.tag == "Player") {
			forestSource.clip = forestDialog[2];
			forestSource.Play ();
		}
		Debug.Log ("Forest Trigger hit");
	}
}
