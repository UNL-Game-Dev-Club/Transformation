using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HappyEndSceneText : MonoBehaviour
{

    Text introText;
    Text whereAmI;
    //float delay = 0.1f;
    int sleepDelay = 75;
    float secondsDelay = 0.075f;
    string text;
    string text2;
    string text3;
    bool typing;
    bool typing2;
    bool typing3;

    int textIndex;

    Coroutine currentCoroutine;
    bool coroutineRunning;

    // Use this for initialization
    void Start()
    {
        introText = GameObject.Find("IntroText").GetComponent<Text>();
        whereAmI = GameObject.Find("WhereAmI").GetComponent<Text>();
        introText.text = "";
        whereAmI.text = "";
        text = "I will never forget that day...\n\nThe day when we were finally free.\n\nAnd I discovered through the comradarie with my friend,\n\nthat I had transformed into the person\n\n";
        text2 = "I was meant to be.";
        typing = true;
        typing2 = true;
        textIndex = 0;

        Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        if (coroutineRunning == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (whereAmI.text == "Thank you for playing!")
                {
                    SceneManager.LoadScene("Credits");
                }
                else
                {
                    introText.text = "";
                    whereAmI.text = "";

                    whereAmI.text = "Thank you for playing!";
                }
            }
        }

        /*if (typing)
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
        }*/


    }

    IEnumerator DisplayText(string t1, string t2)
    {
        coroutineRunning = true;
        int text1Index = 0;
        int text2Index = 0;

        introText.text = "";
        whereAmI.text = "";

        while (text1Index < t1.Length)
        {
            introText.text += t1[text1Index++];

            yield return new WaitForSeconds(secondsDelay);
        }

        yield return new WaitForSeconds(3);

        while (text2Index < t2.Length)
        {
            whereAmI.text += t2[text2Index++];

            yield return new WaitForSeconds(secondsDelay * 2);
        }

        yield return new WaitForSeconds(2);
        coroutineRunning = false;
    }

    void Initialize()
    {
        currentCoroutine = StartCoroutine(DisplayText(text, text2));
    }
}
