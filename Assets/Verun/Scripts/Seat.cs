using System;
using UnityEngine;

namespace Assets.Verun.Scripts
{
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
    }
}
