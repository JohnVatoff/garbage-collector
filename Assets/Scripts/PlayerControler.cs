using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour {

    
    Rigidbody2D rb;
    float speed = 0;


	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

        MovePlayer(speed);
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            speed = -1;
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            speed = 0;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            speed = 1;
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            speed = 0;
        }
    }

    void MovePlayer(float playerSpeed)
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);
    }

}
