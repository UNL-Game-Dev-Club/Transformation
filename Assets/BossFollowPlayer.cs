using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFollowPlayer : MonoBehaviour
{

    GameObject player;
    bool isFollowingPlayer;
    Vector3 playerPos;
    Vector3 thisPos;
    float distMargin = 20.0f;

    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Player");
        isFollowingPlayer = false;
    }

    // Update is called once per frame
    void Update()
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

        if (hypotenuse <= distMargin)
        {
            return true;
        }
        else if (hypotenuse >= distMargin * 3)
        {
            return false;
        }

        return false;
    }
}
