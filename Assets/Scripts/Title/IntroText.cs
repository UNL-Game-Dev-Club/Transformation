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
	void Update () {
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
                typing2 = false;
            }
        }
        else
        {
            System.Threading.Thread.Sleep(3000);
            SceneManager.LoadScene("stage1");
        }
	}

    void Initialize()
    {
    }
}
