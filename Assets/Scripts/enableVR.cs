using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;

public class enableVR : MonoBehaviour {

	void Start()
	{
		StartCoroutine(LoadDevice("cardboard"));
	}

	IEnumerator LoadDevice(string newDevice)
	{
		VRSettings.LoadDeviceByName(newDevice);
		yield return null;
		VRSettings.enabled = true;
	}
}
