using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forestAudio : MonoBehaviour {

	public AudioClip[] forestDialog;
	public AudioSource forestSource;
	public GameObject trigger;

	void Awake(){
		//Start with Forest Whispering - Range from 0-1
		int index = Random.Range(0, 1);
		//forestSource.clip = forestDialog[0];
		forestSource.clip = forestDialog[index];
		forestSource.Play ();
	}

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		int index = Random.Range(0, 6);
		//forestSource.clip = forestDialog[0];
		forestSource.clip = forestDialog[index];
		forestSource.Play ();
	}

	void OnTriggerEnter(Collider collider){
		if (collider.tag == "Player") {
			forestSource.clip = forestDialog[2];
			forestSource.Play ();
		}
		Debug.Log ("Forest Trigger hit");
	}

	IEnumerator questGiven(){
		forestSource.clip = forestDialog [0];
		forestSource.Stop ();
		yield return new WaitForSeconds (forestSource.clip.length);
		forestSource.clip = forestDialog [1];
		forestSource.Play ();
		yield return new WaitForSeconds (forestSource.clip.length);
		forestSource.clip = forestDialog [2];
		forestSource.Play ();
		yield return new WaitForSeconds (forestSource.clip.length);
		forestSource.clip = forestDialog [3];
		forestSource.Play ();

	}
}
