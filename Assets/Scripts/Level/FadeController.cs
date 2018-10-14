using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class FadeController : MonoBehaviour {

    GameObject fadeImage;
    Image fadeImageIMG;
    float i;
    int x = 450;

	// Use this for initialization
	void Start () {
        fadeImage = GameObject.Find("Fade");
        fadeImageIMG = fadeImage.GetComponent<Image>();
        i = 1.0f;
	}
	
	// Update is called once per frame
	void Update () {
        if (x > 0)
        {
            x--;
            return;
        }
        Color c = fadeImageIMG.color;
        c.a = i;
        fadeImageIMG.color = c;
        i -= Time.deltaTime / 1.5f;

        if (i <= 0)
        {
            Destroy(fadeImage.gameObject);
            Destroy(this);
        }
	}
}
