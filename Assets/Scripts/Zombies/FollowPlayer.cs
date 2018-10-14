using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

    GameObject player;
    bool isFollowingPlayer;
    Vector3 playerPos;
    Vector3 thisPos;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
        isFollowingPlayer = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        isFollowingPlayer = CanSeePlayer();
        FollowThePlayer(false);
	}

    public void FollowThePlayer(bool isFollowing)
    {
        if (isFollowing)
        {
            transform.LookAt(player.transform);
            transform.Translate((player.transform.position - transform.position).normalized * 0.05f);
        }
    }

    public bool CanSeePlayer()
    {
        playerPos = GameObject.Find("Player").transform.position;
        thisPos = transform.position;

        float hypotenuse = Mathf.Sqrt(Mathf.Pow((playerPos.y - thisPos.y), 2) + Mathf.Pow((playerPos.x - thisPos.x), 2));

        if (hypotenuse <= 5.0f)
        {
            return true;
        }
        else if (hypotenuse >= 15.0f)
        {
            return false;
        }

        return false;
    }
}
