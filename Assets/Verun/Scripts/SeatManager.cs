using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SeatManager : MonoBehaviour
{
    public GameObject dimensionsObject;
    public GameObject startObject;
    public GameObject seatPrefab;

    private Dimensions dimensions;


    void Start()
    {
        dimensions = dimensionsObject.GetComponent<Dimensions>();

        Vector3 lineStart = startObject.transform.position;
        Debug.Log(lineStart);

        lineStart = new Vector3(lineStart.x, lineStart.y, lineStart.z);

        for (int i = 1; i <= 12; i++)
        {
            Vector3 current = lineStart;

            for (int j = 1; j <= 24; j++)
            {
                var seatObject = Instantiate(seatPrefab, current, Quaternion.identity);
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

}
