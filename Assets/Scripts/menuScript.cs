using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class menuScript : MonoBehaviour
{

    public Canvas quitMenu;
    public Button startText;
    public Button exitText;
    public Button creditsText;

    // Use this for initialization
    void Start()
    {
        Screen.SetResolution(1024, 512, true);
        quitMenu = quitMenu.GetComponent<Canvas>();
        startText = startText.GetComponent<Button>();
        exitText = exitText.GetComponent<Button>();
        creditsText = creditsText.GetComponent<Button>();
        quitMenu.enabled = false;
    }

    public void exitPress()
    {
        quitMenu.enabled = true;
        startText.enabled = false;
        exitText.enabled = false;
        creditsText.enabled = false;
    }

    public void noPress()
    {
        quitMenu.enabled = false;
        startText.enabled = true;
        exitText.enabled = true;
        creditsText.enabled = true;
    }

    public void startLevel()
    {
        SceneManager.LoadScene("PlayScene");
    }

    public void credits()
    {
        SceneManager.LoadScene("credits");
    }

    public void mainMenu()
    {
        SceneManager.LoadScene("mainMenu");
    }

    public void exitGame()
    {
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
