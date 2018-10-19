using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSetupStage2 : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameObject.Find("Player").transform.position = new Vector3(0, 1, 0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
