using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class creditsBack : MonoBehaviour
{

    public Button exitText;

    // Use this for initialization
    void Start()
    {
        exitText = exitText.GetComponent<Button>();
    }

    public void mainMenu()
    {
        SceneManager.LoadScene("mainMenu");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
