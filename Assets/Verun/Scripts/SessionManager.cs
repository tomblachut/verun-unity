using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SessionManager : MonoBehaviour
{
    public GameObject restManagerGameObject;
    private RestManager restManager;
    public GameObject nameField;
    private NamePanel namePanel;

    private void Start ()
	{
	    restManager = restManagerGameObject.GetComponent<RestManager>();
        namePanel = nameField.GetComponent<NamePanel>();

        Debug.Log("Querying");
        restManager.Get("http://172.20.47.233:8080/api/session", ProcessReceivedSession);
        Debug.Log("Queried");
	}


    private void ProcessReceivedSession()
    {
        Debug.Log(restManager.Results.text);
        var session = Session.GetFromJson(restManager.Results.text);
        namePanel.ChangeName(session.name);

        List<Seat> selected = new List<Seat>
        {
            new Seat(1,2),
            new Seat(1,3),
            new Seat(1,3),
        };

        var returnJson = JsonUtility.ToJson(selected);
        Debug.Log(returnJson);

        restManager.Post("http://172.20.47.233:8080/api/reservation", new Dictionary<string, string>
        {
            { "selectedSeats", returnJson} 
        }, ProcessPostAck);
    }

    private void ProcessPostAck()
    {
        Debug.Log("Sent");
    }
}
