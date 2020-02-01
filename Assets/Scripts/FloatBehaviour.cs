﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatBehaviour : MonoBehaviour
{
    float factor = 100;

    public float maxVelocity = 10;
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update() { 
    
    }

    void OnTriggerStay2D(Collider2D hit)
    {
        if (hit.attachedRigidbody)
        {

            if (hit.transform.position.y < transform.position.y + (transform.localScale.y / 2))
            {
                float distance = transform.position.y + (transform.localScale.y/2) - hit.transform.position.y;
                Rigidbody2D rb = hit.GetComponent<Rigidbody2D>();
                rb.AddForce(Vector3.up * rb.mass * factor);

                if (rb.velocity.y > maxVelocity) rb.velocity = new Vector2(rb.velocity.x, maxVelocity);
            }
           
        }
    }

    void increaseLevel()
    {

    }

    void decreaseLevel()
    {

    }

}
