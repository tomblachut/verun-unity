using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

[Serializable]
public class Reservation
{
    public List<Seat> selectedSeats;

    public static Reservation GetFromJson(string json)
    {
        return JsonUtility.FromJson<Reservation>(json);
    }
}
