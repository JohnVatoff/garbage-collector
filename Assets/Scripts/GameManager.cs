using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject trash;
    float timeLeft = 4.0f;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            Instantiate(trash, new Vector2(0, 0), Quaternion.identity);
            timeLeft = Random.Range(2, 6);
        }
    }
}
