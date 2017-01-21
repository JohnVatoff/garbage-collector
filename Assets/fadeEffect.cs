using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class fadeEffect : MonoBehaviour {

    public SpriteRenderer text;
    public float fade;
    public bool fadeIn, fadeOut;
    public bool nextScene = false;

    void Start()
    {
        fade = 0.0f;
    }

    // Update is called once per frame
    void Update () {
        if (fade >= 1.0f)
        {
            fadeOut = true;
            fadeIn = false;
            nextScene = true;
        }
        if(fade <= 0.0f)
        {
            fadeIn = true;
            fadeOut = false;
            if(nextScene)
            {
                SceneManager.LoadScene("mainMenu");
            }
        }
        if(fadeIn)
        {
            fade += 0.005f;
        }
        if(fadeOut)
        {
            fade -= 0.005f;
        }
        text.color = new Color(1f, 1f, 1f, fade);
    }
}
