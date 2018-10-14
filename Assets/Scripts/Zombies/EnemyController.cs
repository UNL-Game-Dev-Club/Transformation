using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    GameObject target;
    Vector3 targetPos;
    Vector3 enemyPos;
    float xdiff;
    float zdiff;

	// Use this for initialization
	void Start () {
        target = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
        targetPos = target.transform.position;
        enemyPos = transform.position;

        xdiff = targetPos.x - enemyPos.x;
        zdiff = targetPos.z - enemyPos.z;

        if (Mathf.Abs(xdiff) != 0 || Mathf.Abs(zdiff) != 0)
        {
            transform.LookAt(target.transform);
            transform.Translate(Vector3.forward * 0.01f);
        }
	}
}
