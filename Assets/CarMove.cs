using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMove : MonoBehaviour
{
    const float ACCELERATION = 0.001f;
    const float DECELERATION = -0.0008f;
    const float MAX_SPEED = 0.5f;
    const float MAX_BACK_SPEED = -0.4f;

    Rigidbody rb;
    float speed;
    float backSpeed;
    Vector3 move;
    // Start is called before the first frame update
    void Start()
    {
        speed = 0;
        move = Vector3.zero;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow) && speed < MAX_SPEED) {
            speed += ACCELERATION;
        }
        else {
            if (speed > 0 ) {
                speed += DECELERATION;
            }
            else {
                speed = 0;
            }
        }

        if (Input.GetKey(KeyCode.DownArrow) && backSpeed < MAX_BACK_SPEED) {
            backSpeed += DECELERATION;
        }
        else {
            if (backSpeed < 0 ) {
                backSpeed += ACCELERATION;
            }
            else {
                backSpeed = 0;
            }
        }

        move = transform.up * (speed + backSpeed);

        rb.MovePosition(rb.position + move);
    }
}
