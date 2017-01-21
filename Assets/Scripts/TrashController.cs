using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashController : MonoBehaviour {

    Rigidbody2D rb;
    public AudioClip sound;
    private AudioSource source;

    // Use this for initialization
    void Start ()
    {
        source = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(0, 10), ForceMode2D.Impulse);
    }
	
	// Update is called once per frame
	void Update ()
    {
       
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Ground")
        {
            Debug.Log("coll");
            source.PlayOneShot(sound, 1);
            Destroy(this.gameObject);
        }
    }
}
