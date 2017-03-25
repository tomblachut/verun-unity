using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Response : MonoBehaviour
{
	public GameObject RestManagerGameObject;
	private RestManager restManager;
	public GameObject NameField;
	public GameObject SM;
	private NamePanel namePanel;
	private SeatManager sm;

	// Use this for initialization
	void Start () {
		restManager = restManagerGameObject.GetComponent<RestManager>();
		namePanel = nameField.GetComponent<NamePanel>();
		sm = SM.GetComponent<SeatManager> ();

		Debug.Log("Querying");
		restManager.Post("http://172.20.47.233:8080/api/session", ProcessCurrentSession);
		Debug.Log("Queried");
	}

	private Dictionary<string, string> ProcessCurrentSession()
	{
		return new Dictionary<string, string> { 
			"selectedSeats", getSelectedSeats()
		};	
	}

	private string getSelectedSeats() {
		string response = "";
		foreach (var seat in sm.GetComponentsInChildren<SeatComponent>()) {
			if (seat.Reserved == true) {
				response += JsonUtility.ToJson (seat.getSeat());
			}
		}
		return response;
	}

	// Update is called once per frame
	void Update () {
		
	}
}
