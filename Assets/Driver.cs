using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    // Variables to control the car's behaviour
    [SerializeField] float steerSpeed = 200f;
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float slowSpeed = 5f;
    [SerializeField] float boostSpeed = 15f;

    void OnCollisionEnter2D(Collision2D other) 
    {
        Debug.Log("Boink!");
        moveSpeed = slowSpeed;
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Booster")
        {
            Debug.Log("Zoom");
            moveSpeed = boostSpeed;
        }
        else if (other.tag == "CarParkTrigger")
        {
            Debug.Log("Ding Ding!");
        }
    }

    // Update is called once per frame
    void Update()
    {
                float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
                float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
                transform.Rotate(0,0,-steerAmount);
                transform.Translate(0,moveAmount,0);
                
    }
}
