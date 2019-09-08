using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controls : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string keyboardControls = "Keyboard Controls:\n------------------------\nClick to Attack\nWASD / Arrow Keys to Move\nClick to interact with friend";
        string joystickControls = "Controller:\n------------\nA to Attack\nLeft Joystick to Move\nA to interact with friend";

        Text controlsText = GetComponent<Text>();

        string[] names = Input.GetJoystickNames();
        foreach (string n in names)
        {
            Debug.Log("Joystick: " + n);
        }

        if (names[0] != "")
        {
            controlsText.text = joystickControls;
        }
        else
        {
            controlsText.text = keyboardControls;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
