using System;
using UnityEngine;

[Serializable]
public class Seat
{
    public int row;
    public int column;
    public bool reserved = true;

    public static Seat GetFromJson(string json)
    {
        return JsonUtility.FromJson<Seat>(json);
    }

    public override string ToString()
    {
        return row + "-" + column;
    }

    public Seat(int row, int column, bool reserved = true)
    {
        this.row = row;
        this.column = column;
        this.reserved = reserved;
    }

}
