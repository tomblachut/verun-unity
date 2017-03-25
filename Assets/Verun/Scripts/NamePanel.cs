using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NamePanel : MonoBehaviour
{
    private Text _text;

    private void Start ()
	{
	    _text = GetComponentInChildren<Text>();

        ChangeName("C#");

	}

    public void ChangeName(string text)
    {
        _text.text = ("Hello " + text).ToUpper();
    }

}
