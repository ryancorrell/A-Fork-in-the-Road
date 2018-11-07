using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookAtMe : MonoBehaviour {

	//Look at Target
	//public Transform player;
	Transform target;

	// Use this for initialization
	void Start () {

		target = GameObject.FindGameObjectWithTag ("Player").transform;

	}
	
	// Update is called once per frame
	void Update () {
		
		if (target != null) {

			transform.LookAt (new Vector3(target.position.x, transform.position.y, target.position.z));
				
		}

	}
}
