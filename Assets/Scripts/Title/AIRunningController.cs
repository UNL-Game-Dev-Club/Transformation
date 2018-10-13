using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class AIRunningController : MonoBehaviour {

    bool isRunning;

	// Use this for initialization
	void Start () {
        isRunning = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (!isRunning)
        {
            Debug.Log("Starting running");
            isRunning = true;
            GetComponent<ThirdPersonCharacter>().Move(new Vector3(13, 0, 0), false, false);

        }
	}
}
