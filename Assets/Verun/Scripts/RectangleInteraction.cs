using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RectangleInteraction : MonoBehaviour
{

    private Image panel;
    private Color current = Color.yellow;

    private void Start ()
    {
        panel = GetComponent<Image>();
//        StartCoroutine(CycleColor());
    }

    private void Update ()
	{
        if (Input.GetButton("Fire1"))
        {
            panel.color = Color.Lerp(Color.yellow, Color.red, Mathf.PingPong(Time.time, 1));
        }
        else
        {
            panel.color = Color.white;
        }
	}

    private IEnumerator CycleColor()
    {
        while (true)
        {
            current = current == Color.yellow ? Color.blue : Color.yellow;
            yield return new WaitForSeconds(0.5f);
        }
    }

}
