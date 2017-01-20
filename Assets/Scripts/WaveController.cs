using UnityEngine;

public class WaveController : MonoBehaviour {

    Rigidbody2D rb;
    public float waveAmplitude = 1;
    bool change;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
;	}
	
	// Update is called once per frame
	void Update () {
        if (change)
        {
            waveAmplitude += 1 * Time.deltaTime;
            if (waveAmplitude > 2)
                change = false;
        }
        else
        {
            waveAmplitude -= 1 * Time.deltaTime;
            if (waveAmplitude < -2)
                change = true;
        }

        rb.velocity = new Vector2(waveAmplitude, rb.velocity.y);
    }
}
