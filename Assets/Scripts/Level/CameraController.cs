using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    GameObject player;
    Vector3 playerPos;
    Vector3 playerPos_CameraTarget;
    Vector3 thisPos;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update ()
    {
        this.transform.RotateAroundLocal(Vector3.up, player.transform.rotation.y - transform.rotation.y);
        //transform.LookAt(playerPos_CameraTarget);
        playerPos = player.transform.position;
        playerPos_CameraTarget = playerPos;
        playerPos_CameraTarget.y += 1.5f;
        //this.transform.position = new Vector3(playerPos.x, playerPos.y + 2.5f, playerPos.z - 4);


        // this.transform.Rotate(Vector3.up, player.transform.rotation.eulerAngles.y);
    }
}
