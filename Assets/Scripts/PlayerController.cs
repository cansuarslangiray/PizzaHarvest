using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;
    private float speed = 10.0f;
    private float xRange = 10f;
    private float zRange = 20f;
    public GameObject pizzaPrefabs;
    public int Score;
    public int hearth = 3;

    void Start()
    {
    }


    void Update()
    {
        Movement();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(pizzaPrefabs, transform.position, pizzaPrefabs.transform.rotation);
        }

        Debug.Log(Score);
    }

    void Movement()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.z < -zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zRange);
        }

        if (transform.position.z > zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRange);
        }

        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Obstacle"))
        {
            hearth--;
            Debug.Log("hearth: " + hearth);
            if (hearth == 0)
            {
                Debug.Log("GAMEEE OVERRR!!!!");
            }
        }
    }
}