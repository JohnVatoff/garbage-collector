using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class gameMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void startLevel()
    {
        SceneManager.LoadScene("LoadingScene");
    }

    public void mainMenu()
    {
        SceneManager.LoadScene("mainMenu");
    }
}
