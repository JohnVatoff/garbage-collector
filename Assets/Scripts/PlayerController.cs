using UnityEngine;

public class PlayerController : MonoBehaviour {

    
    Rigidbody2D rb;
    public float speed = 0;
    Animator anim;
    double speedLimit = 10;
    bool stun = false;
    public bool controlsAllowed = true;


    // Use this for initialization
    void Start () {
        Screen.SetResolution(1024, 512, true);
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        anim.SetInteger("State", 0);
    }
	
	// Update is called once per frame
	void Update () {
        if (!stun && controlsAllowed)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                if (speed > -speedLimit)
                    speed += -5 * Time.deltaTime;
            }
            if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                speed = 0;
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                if (speed < speedLimit)
                    speed += 5 * Time.deltaTime;
            }
            if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                speed = 0;
            }

            MovePlayer(speed);
        }
        else
        {
            speed = 0;
        }

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
            rb.position = new Vector2(-9.9f, -3.0f);
        else
            rb.position = new Vector2(9.9f, -3.0f);
    }

    public void GetDammage()
    {
        stun = true;
        anim.SetInteger("State", 3);
    }
    public void ReleaseDammage()
    {
        stun = false;
        anim.SetInteger("State", 0);
    }
}
