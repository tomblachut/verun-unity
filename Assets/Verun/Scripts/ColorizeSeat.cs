using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorizeSeat : MonoBehaviour {

	public Material green;
	public Renderer rend;

	void Start() {
		rend = gameObject.GetComponent<Renderer>();
		rend.enabled = true;
	}

	void Update() {

		Material[] mats = rend.materials;
		mats[0] = green; 
		GetComponent<Renderer>().materials = mats;
	}
}
