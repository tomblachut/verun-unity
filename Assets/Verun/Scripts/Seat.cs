using System;
using UnityEngine;

[Serializable]
public class Seat : IEquatable<Seat>
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

    public bool Equals(Seat other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return row == other.row && column == other.column;
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Seat) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return (row*397) ^ column;
        }
    }

    public static bool operator ==(Seat left, Seat right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(Seat left, Seat right)
    {
        return !Equals(left, right);
    }
}
