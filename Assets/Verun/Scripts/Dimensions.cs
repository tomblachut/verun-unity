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
    public GameObject last;

    private float realWidth;

    private void Start()
    {
        var dist = last.transform.position - start.transform.position;
        realWidth = dist.x;
    }

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

    public Rect Right(Rect current, float totalWith)
    {
        var ratio = totalWith/realWidth;
        Vector2 realDist = next.transform.position - start.transform.position;
        return new Rect(current.position + (ratio * realDist), current.size);
    }

    public Rect RightStep(Rect current, float totalWith)
    {
        var ratio = totalWith / realWidth;
        Vector2 realDist = away.transform.position - edge.transform.position;
        return new Rect(current.position + (ratio * realDist), current.size);
    }
}
