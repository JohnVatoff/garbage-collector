using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    static AudioSource source;
    public AudioClip pickupSound;
    public Text pointsText;
    public Text timeText;
    public int points;
    float time = 300;

    public GameObject trash;
    float respawn = 4.0f;

    // Use this for initialization
    void Start ()
    {
        points = 0;
        source = GetComponent<AudioSource>();
        //canvas.Find("ObjectName");
        //canvas.GetComponentInChildren(Text).GetComponent();
        //canvas.GetComponent<UnityEngine.UI.Text>().text = "alabala";
        

    }
	
	// Update is called once per frame
	void Update ()
    {
        respawn -= Time.deltaTime;
        if (respawn < 0)
        {
            Instantiate(trash, new Vector2(0, 0), Quaternion.identity);
            respawn = Random.Range(2, 6);
        }
    }

    void LateUpdate()
    {
        pointsText.text = "Points: " + points.ToString();
    }

    public void PickUp()
    {
        Debug.Log("Pick item");
        points++;
        source.PlayOneShot(pickupSound, 1);
    }
}
