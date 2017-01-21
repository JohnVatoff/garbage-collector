using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropHelmet : MonoBehaviour {

    public GameObject gm;
    GameManager gmScript;
    Rigidbody2D rb;

    // Use this for initialization
    void Start()
    {
        gmScript = gm.GetComponent<GameManager>();
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(0, 8), ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Ground")
        {
            Destroy(this.gameObject);
        }
        if (coll.gameObject.tag == "Bag" || coll.gameObject.tag == "Player")
        {
            gmScript.AddHelmet();
            Destroy(this.gameObject);
        }

    }
}
