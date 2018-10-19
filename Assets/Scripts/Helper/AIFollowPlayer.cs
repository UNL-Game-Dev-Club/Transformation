using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIFollowPlayer : MonoBehaviour {

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
        CanSeePlayer();
        FollowThePlayer(isFollowingPlayer);
	}

    public void FollowThePlayer(bool isFollowing)
    {
        if (isFollowing)
        {
            transform.LookAt(player.transform);
            transform.Translate((player.transform.position - transform.position).normalized * 0.05f);
        }
    }

    public void CanSeePlayer()
    {
        playerPos = GameObject.Find("Player").transform.position;
        thisPos = transform.position;

        float hypotenuse = Mathf.Sqrt(Mathf.Pow((playerPos.y - thisPos.y), 2) + Mathf.Pow((playerPos.x - thisPos.x), 2));
        Debug.Log(hypotenuse);

        if (hypotenuse >= 15.0f)
        {
            isFollowingPlayer = false;
            GameObject.Find("HelperManager").GetComponent<HelperManagerController>().LostHelper();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.name == "Player")
        {
            if (Input.GetMouseButtonDown(0) || Input.GetAxis("Fire1") > 0)
            {
                Debug.Log("Following the player");
                isFollowingPlayer = true;
                GameObject.Find("HelperManager").GetComponent<HelperManagerController>().GainHelper();
            }
        }
    }
}
