using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionDestroyer : MonoBehaviour {

    float despawnTime;
    // Use this for initialization
    void Start()
    {
        despawnTime = 1.7f;
    }

    // Update is called once per frame
    void Update()
    {
        despawnTime -= Time.deltaTime;
        if (despawnTime < 0)
            Destroy(this.gameObject);
    }
}
