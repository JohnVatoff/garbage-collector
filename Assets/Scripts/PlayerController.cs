using UnityEngine;

public class PlayerController : MonoBehaviour {

    
    Rigidbody2D rb;
    public float speed = 0;
    Animator anim;


    // Use this for initialization
    void Start () {
        Screen.SetResolution(1024, 512, true);
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        anim.SetInteger("State", 0);
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.LeftArrow))
        {

            speed += -5 * Time.deltaTime;
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            speed = 0;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            speed += 5 * Time.deltaTime;
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            speed = 0;
        }

        MovePlayer(speed);
    }

    void MovePlayer(float playerSpeed)
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);
        if (speed > 0)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
            anim.SetInteger("State", 1);
        }
        else if (speed < 0)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
            anim.SetInteger("State", 1);
        }
        else
        {
            anim.SetInteger("State", 0);
        }


    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Teleport")
        {
            this.TeleportToPosition();
        }
    }

    void TeleportToPosition()
    {
        if (rb.position.x > 0)
            rb.position = new Vector2(-10.14f, -3.0f);
        else
            rb.position = new Vector2(10.14f, -3.0f);
    }

}
