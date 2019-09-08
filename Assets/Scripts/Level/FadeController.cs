using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class FadeController : MonoBehaviour {

    [SerializeField] GameObject fadeImage;
    GameObject fadeBackground;
    RawImage fadeImageIMG;
    float i;
    int x = 100;

    [SerializeField] GameObject loadingText;

    // Use this for initialization
    void Start () {
        fadeImageIMG = fadeImage.GetComponent<RawImage>();
        i = 1.0f;

        StartCoroutine(FadeImageOut());
	}
	
	// Update is called once per frame
	void Update () {

	}

    IEnumerator FadeImageOut()
    {
        yield return new WaitForSeconds(7.8f);

        Color start = fadeImageIMG.color;
        Color end = fadeImageIMG.color;
        end.a = 0;
        Destroy(loadingText.gameObject);

        for (i = 0.0f; i < 1.5f; i += Time.deltaTime)
        {
            fadeImageIMG.color = Color.Lerp(start, end, i / 1.5f);
            yield return new WaitForEndOfFrame();
        }

        Destroy(fadeImage.gameObject);
        Destroy(this);
    }
}
