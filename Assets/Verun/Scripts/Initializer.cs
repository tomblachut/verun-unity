using System;
using SimpleJSON;
using UnityEngine;
using System.Collections;


public struct RoomData
{
	public int Id;
	public int SeatNumber;
	public ArrayList SeatsReserved;
}

public class Initializer : MonoBehaviour
{
	IEnumerator Start()
	{
		string url = "172.20.47.233:8080/api/room";
		WWW www = new WWW (url);
		yield return www;
		if (www.error == null) {
			ProcessJSONData (www.text);
		}
	}

	private void ProcessJSONData(string jsonData) {
		var parsedJSON = JSON.Parse (jsonData);

	}
}
