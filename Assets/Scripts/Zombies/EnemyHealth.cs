using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

    const int MAX_HEALTH = 5;
    int health;

	// Use this for initialization
	void Start () {
        health = 5;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void TakeHit()
    {
        health--;
        if (health == 0)
        {
            DropLoot();

            Debug.Log("Killed " + this.name);
            Destroy(this.gameObject);
        }
        Debug.Log("Health now at " + health);
    }

    public void DropLoot()
    {
        // TODO: Drop random loot
    }
}
