using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftAndRight : MonoBehaviour
{
    public float speed, distance;
    private float minX, maxX;

    public bool right, dontMove;
    private bool stop;

    void Start()
    {
        maxX = transform.position.x + distance;
        minX = transform.position.x - distance;
    }

    void Update()
    {
        if(!stop && !dontMove)
        {
            if (right)
            {
                transform.position += Vector3.right * speed * Time.deltaTime;
                if (transform.position.x >= maxX)
                    right = false;
            }
            else
            {
                transform.position += Vector3.left * speed * Time.deltaTime;
                if (transform.position.x <= minX)
                    right = true;
            }
        }
    }

    void OnCollisionEnter(Collision target)
    {
        if(target.gameObject.tag == "White" && target.gameObject.GetComponent<Rigidbody>().velocity.magnitude > 1 
            || target.gameObject.name == "Player")
        {
            stop = true;
            GetComponent<Rigidbody>().freezeRotation = false;
        }
    }
}
