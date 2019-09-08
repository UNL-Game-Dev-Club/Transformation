using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroText : MonoBehaviour {

    Text introText;
    Text whereAmI;
    //float delay = 0.1f;
    int sleepDelay = 75;
    string text;
    string text2;
    string text3;
    bool typing;
    bool typing2;

    int textIndex;

    // Use this for initialization
    void Start () {
        introText = GameObject.Find("IntroText").GetComponent<Text>();
        whereAmI = GameObject.Find("WhereAmI").GetComponent<Text>();
        introText.text = "";
        whereAmI.text = "";
        text = "It was the year 2068.\n\nWorld War III was upon us, so I signed up as a volunteer for the U.S. Army.\n\nLittle did I know what was to become of me when I did...";
        text2 = "WHERE AM I???";
        text3 = "Congratulations, soldier. You have been selected to be a part of the special weapons project. You belong to the government now, so please try your best to be cooperative. Any attempts to escape will be futile.";
        typing = true;
        typing2 = true;
        textIndex = 0;

        Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        if (!typing || !typing2)
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

        SceneManager.LoadScene("testStage");
    }
}
