using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeatComponent : MonoBehaviour {

    public int Row = 0;
    public int Column = 0;

    public Seat GetSeat()
    {
        return new Seat(Row, Column);
    }
}
