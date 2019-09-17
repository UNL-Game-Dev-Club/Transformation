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
    bool clickable;

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
        clickable = false;
        textIndex = 0;

        Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        if (clickable)
        {
            if (introText.text == text)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    introText.text = "";
                    whereAmI.text = "";

                    whereAmI.text = "Thank you for playing!";
                }
            }
            else if (whereAmI.text == "Thank you for playing!")
            {
                if (Input.GetMouseButtonDown(0))
                {
                    SceneManager.LoadScene("Credits");
                }
            }
        }
    }

    void Initialize()
    {
        StartCoroutine(DisplayWhereAmI(text, text2));
    }

    IEnumerator DisplayWhereAmI(string displayText, string whereAmIText)
    {
        foreach (char c in displayText)
        {
            introText.text += c;
            yield return new WaitForSeconds(0.075f);
        }

        foreach (char c in whereAmIText)
        {
            whereAmI.text += c;
            yield return new WaitForSeconds(0.075f * 3);
        }

        yield return new WaitForSeconds(1);
        clickable = true;
    }
}
