using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

//[ExecuteInEditMode]
public class SeatManager : MonoBehaviour
{
    public GameObject dimensionsObject;
    public GameObject startObject;
    public GameObject seatPrefab;
    public GameObject miniSeatPrefab;

    public GameObject Minimap;

    private Dimensions dimensions;

    public List<Seat> selected = new List<Seat>();
    public List<Seat> inactive = new List<Seat>();


    void Start()
    {
        dimensions = dimensionsObject.GetComponent<Dimensions>();

        InstantiateSeats();
//        DrawMinimap();

        inactive.Add(new Seat(1,1));

//        ResetColors();
    }

    private void InstantiateSeats()
    {
        Vector3 lineStart = startObject.transform.position;

        lineStart = new Vector3(lineStart.x, lineStart.y, lineStart.z);

        for (int i = 1; i <= 12; i++)
        {
            Vector3 current = lineStart;

            for (int j = 1; j <= 24; j++)
            {
                var seatObject = Instantiate(seatPrefab, current, Quaternion.identity, transform);
                var seatComponent = seatObject.GetComponent<SeatComponent>();
                seatComponent.Row = i;
                seatComponent.Column = j;


                if (j == 3 || j == 21)
                {
                    current = dimensions.RightStep(current);
                }
                else
                {
                    current = dimensions.Right(current);
                }
            }
            lineStart = dimensions.Top(lineStart);
        }
    }

    private void ResetColors()
    {
        foreach (var seat in inactive)
        {
            Debug.Log(seat);
        }

        foreach (Transform seatObject in transform)
        {

            var colorize = GetComponentInChildren<ColorizeSeat>();
            var seat = GetComponent<SeatComponent>();

            if (seat != null && inactive.Contains(seat.GetSeat()))
            {
                Debug.Log("hit");
                colorize.SetInactive();
            }
            else
            {
                colorize.SetNormal();
            }

        }
    }

//    private void DrawMinimap()
//    {
//        RectTransform t = Minimap.GetComponent<RectTransform>();
//
//        Vector2 current = Vector2.zero;
//
//        for (int j = 1; j <= 24; j++)
//        {
//            var seatObject = Instantiate(miniSeatPrefab);
//            var rectTransform = seatObject.GetComponent<RectTransform>();
////            rectTransform.rect = new Rect(current, rectTransform.rect.size);
////            rectTransform.rect.position = current;
//
//
//            if (j == 3 || j == 21)
//            {
//                current = dimensions.RightStep(current);
//            }
//            else
//            {
//                current = dimensions.Right(current);
//            }
//        }
//    }

}
