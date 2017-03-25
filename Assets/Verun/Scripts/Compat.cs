using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compat : MonoBehaviour {

	// Use this for initialization
	void Start () {
        if (SteamVR.instance != null)
        {
            Debug.Log("VR detected");
            enabled = false;
        }
        transform.localPosition = new Vector3(0, 1f, 0);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
