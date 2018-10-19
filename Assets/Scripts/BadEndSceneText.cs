using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BadEndSceneText : MonoBehaviour
{

    Text introText;
    Text whereAmI;
    //float delay = 0.1f;
    int sleepDelay = 75;
    string text;
    string text2;
    string text3;
    bool typing;
    bool typing2;
    bool typing3;

    int textIndex;

    // Use this for initialization
    void Start()
    {
        introText = GameObject.Find("IntroText").GetComponent<Text>();
        whereAmI = GameObject.Find("WhereAmI").GetComponent<Text>();
        introText.text = "";
        whereAmI.text = "";
        text = "(I failed to ensure my friend's safety, and failed to escape myself.)\n\nCongratulations soldier. The project is now complete!";
        text2 = "WHAT AM I? A MONSTER?!?";
        typing = true;
        typing2 = true;
        textIndex = 0;

        Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        if (typing)
        {
            introText.text += text[textIndex++];
            if (textIndex == text.Length)
            {
                typing = false;
                System.Threading.Thread.Sleep(1500);
                textIndex = 0;
            }

            System.Threading.Thread.Sleep(sleepDelay);
        }
        else if (typing2)
        {
            whereAmI.text += text2[textIndex++];
            System.Threading.Thread.Sleep(sleepDelay * 3);
            if (textIndex == text2.Length)
            {
                textIndex = 0;
                typing2 = false;
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                introText.text = "";
                whereAmI.text = "";

                whereAmI.text = "Thank you for playing!";
            }
        }

        if (whereAmI.text == "Thank you for playing!")
        {
            if (Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene("Credits");
            }
        }
    }

    void Initialize()
    {
    }
}
