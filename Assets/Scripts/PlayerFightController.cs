using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFightController : MonoBehaviour {

    List<string> enemies;

	// Use this for initialization
	void Start () {
        enemies = new List<string>();

        enemies.Add("Zombie");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    
    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("Name: " + collision.collider.name + ", Tag: " + collision.collider.tag);
        if (enemies.Contains(collision.collider.tag))
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("Attacking Zombie");
                Attack(collision.collider.gameObject);
            }
        }
    }

    private void Attack(GameObject other)
    {
        other.GetComponent<EnemyHealth>().TakeHit();
    }
}
