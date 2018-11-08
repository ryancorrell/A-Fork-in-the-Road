using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bumpTree : MonoBehaviour {

	public Collider col;

	// Use this for initialization
	void Start () {
		col = GetComponent<Collider> ();
		col.isTrigger = true;
	}
	
	void OnCollisionEnter(Collision c){
		Debug.Log ("tree hit");
		// force of the tree
		float force = 3;

		if (c.gameObject.tag == "fallenTree") {
			//Calc the collision point
			Vector3 dir = c.contacts[0].point - transform.position;

			dir = -dir.normalized;

			GetComponent<Rigidbody> ().AddForce (dir * force);
		}

	}
}
