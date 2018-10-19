using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossHealth : MonoBehaviour {

    const int MAX_HEALTH = 5;

    [SerializeField]
    int health;

	// Use this for initialization
	void Start () {
        health = 50;
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
            if (GameObject.Find("HelperManager").GetComponent<HelperManagerController>().HappyScene)
            {
                SceneManager.LoadScene("HAPPY_end_scene");
            }
            else
            {
                SceneManager.LoadScene("BAD_end_scene");
            }
        }
        Debug.Log("Health now at " + health);
    }

    public void DropLoot()
    {
        // TODO: Drop random loot
    }
}
