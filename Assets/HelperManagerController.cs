using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelperManagerController : MonoBehaviour {

    bool happyScene;

	// Use this for initialization
	void Start () {
        happyScene = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GainHelper()
    {
        happyScene = true;
    }

    public void LostHelper()
    {
        happyScene = false;
    }

    public bool HappyScene
    {
        get
        {
            return happyScene;
        }
    }
}
