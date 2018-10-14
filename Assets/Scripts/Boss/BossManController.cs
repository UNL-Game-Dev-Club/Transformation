using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class BossManController : MonoBehaviour {

    int boundary_X_Lower = -82;
    int boundary_X_Upper = -56;
    int boundary_Z_Upper = 71;
    int boundary_Z_Lower = 46;

    float y = 0.6f;

    bool seePlayer = false;

    ThirdPersonCharacter tpc;
    GameObject player;
    bool isFollowingPlayer;
    Vector3 playerPos;
    Vector3 thisPos;

    bool isMoving;

    Vector3 translationDestination;

    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Player");
        isFollowingPlayer = false;
        isMoving = false;
        tpc = GetComponent<ThirdPersonCharacter>();
        translationDestination = transform.position;
    }

    /* Set random goal,
     * Wait for him to arrive
     *  Check if he sees the player
     *      If he does, cancel translation and follow player
     * Repeat
     */

    Vector3 SetRandomDest()
    {
        float x = Random.Range(boundary_X_Lower, boundary_X_Upper);
        float z = Random.Range(boundary_Z_Lower, boundary_Z_Upper);
        Vector3 dest = new Vector3(x, y, z);
        translationDestination = dest;
        Debug.Log(dest);

        return dest;
    }

    // Update is called once per frame
    void Update () {

        // Check if sees the player
        seePlayer = CanSeePlayer();

        Debug.Log("Can see the player? " + seePlayer);

        if (seePlayer)
        {
            FollowThePlayer(seePlayer);
            isMoving = true;
        }
        else
        {
            isMoving = !NearDestination(translationDestination);
            Debug.Log("is moving ? " + isMoving);

            if (!isMoving)
            {
                Vector3 pos = transform.position;
                // Set random destination
                isMoving = true;
                Vector3 randomDest = SetRandomDest();

                Vector3 destDiff = (randomDest - pos).normalized * 0.05f;

                Debug.Log("Diff = " + destDiff);

                transform.Translate(destDiff);
            }
        }
	}

    public bool NearDestination(Vector3 dest)
    {
        Vector3 pos = transform.position;
        float xdiff = pos.x - dest.x;
        float zdiff = pos.z - dest.z;

        if (Mathf.Abs(xdiff) < 2.0f && Mathf.Abs(zdiff) < 2.0f)
        {
            return true;
        }
        else
        {
            return false;
        }
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

        if (hypotenuse <= 20.0f)
        {
            return true;
        }
        else if (hypotenuse >= 60.0f)
        {
            return false;
        }

        return false;
    }
}
