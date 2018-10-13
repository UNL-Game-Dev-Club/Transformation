using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

    GameObject player;
    bool isFollowingPlayer;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
        isFollowingPlayer = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (isFollowingPlayer)
        {
            transform.LookAt(player.transform);
            transform.Translate((player.transform.position - transform.position) * 0.01f);
        }
	}

    private void OnTrigger(Collider other)
    {
        if (other.name == "Player")
        {
            Debug.Log("Found player");
            isFollowingPlayer = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Player")
        {
            isFollowingPlayer = true;
        }
    }
}
