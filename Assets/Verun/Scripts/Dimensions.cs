using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dimensions : MonoBehaviour
{

    public GameObject start;
    public GameObject next;
    public GameObject edge;
    public GameObject away;
    public GameObject top;

    public Vector3 Right(Vector3 current)
    {
        return current + next.transform.position - start.transform.position;
    }

    public Vector3 RightStep(Vector3 current)
    {
        return current + away.transform.position - edge.transform.position;
    }

    public Vector3 Top(Vector3 current)
    {
        return current + top.transform.position - edge.transform.position;
    }

}
