using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiceMover : MonoBehaviour
{
    private static float baseSpeed = 5;
    private float speed = 0;

    private float slowDuration = 0;

    // Start is called before the first frame update
    void Start()
    {
        speed = baseSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        float xValue = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        transform.Translate(-xValue, 0f, -speed * Time.deltaTime);

        slowDuration = slowDuration - 1;
        if (slowDuration <= 0) {
            speed = baseSpeed;
            transform.gameObject.GetComponent<MeshRenderer>().material.color = Color.gray;
        } else {
            transform.gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
        }
    }

    // Detect collisions between the GameObjects with Colliders attached
    void OnCollisionEnter(Collision collision)
    {
        var tag = collision.gameObject.tag;
        Debug.Log(tag);

        // Prevent slowness from being applied if they're already slowed
        if (slowDuration > 0) {
            return;
        }
        
        if (tag == "Natto")
        {
            speed = 3.5f;
            slowDuration = 120;
        } 
        else if (tag == "Sticky")
        {
            speed = 1.5f;
            slowDuration = 120;
        }
        else if (tag == "StickyNatto")
        {
            speed = 0f;
            slowDuration = 120;
        }
    }
}
