using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

[Serializable]
public class Session
{
    public string name;
    public int rowNum;
    public int columnNum;
    public List<Seat> reservedSeats;

    public static Session GetFromJson(string json)
    {
        return JsonUtility.FromJson<Session>(json);
    }
}
