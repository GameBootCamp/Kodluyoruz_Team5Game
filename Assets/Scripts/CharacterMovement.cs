using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float speed = 10f;
    public float jumpSeed = 10f;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Touch count = Input.GetTouch(0);
        //if (count.phase==TouchPhase.Began)
        //{
        //    rb.AddForce(0, 11f, 1f);
        //}

        if(Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(0, 15f, 2f);
        }
    }
}
