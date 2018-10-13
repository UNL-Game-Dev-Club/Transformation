using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(this);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /// <summary>
    /// Loads a new scene using Unity's SceneManager
    /// </summary>
    /// <param name="level">Name of the new scene to be loaded</param>
    public void Load(string level)
    {
        SceneManager.LoadScene(level);
    }

    /// <summary>
    /// Loads a new scene using Unity's SceneManager
    /// </summary>
    /// <param name="level">Build index of the new scene to be loaded</param>
    public void Load(int level)
    {
        SceneManager.LoadScene(level);
    }

    public void Quit()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
