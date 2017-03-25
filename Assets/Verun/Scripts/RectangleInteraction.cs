using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RectangleInteraction : MonoBehaviour
{

    private Image panel;

    private void Start ()
    {
        panel = GetComponent<Image>();
    }

    private void Update ()
	{
        if (Input.GetButton("Fire1"))
        {
            panel.color = Color.yellow;
        }
        else
        {
            panel.color = Color.white;
        }
	}
}
