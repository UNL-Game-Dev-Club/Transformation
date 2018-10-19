using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFightController : MonoBehaviour {

    List<string> enemies;

	// Use this for initialization
	void Start () {
        enemies = new List<string>();

        enemies.Add("Zombie");
        enemies.Add("Boss");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Attack(GameObject other)
    {
        if (enemies.Contains(other.tag))
        {
            Debug.Log(other.name);

            if (other.name == "BossMan")
                other.GetComponent<BossHealth>().TakeHit();
            else
                other.GetComponent<EnemyHealth>().TakeHit();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetMouseButtonDown(0) || Input.GetAxis("Fire1") > 0)
        {
            Attack(other.gameObject);
        }
    }
}
