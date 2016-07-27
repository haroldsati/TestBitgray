﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UITextSetter : MonoBehaviour
{
    Text text;

    private void Initialize()
    {
        if (text == null)
            text = gameObject.GetComponent<Text>();
    }

    protected void UpdateText(string message)
    {
        Initialize();
        text.text = message;
    }
}