using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float speed = 10.0f;
    public float xRange = 10f;
    public GameObject pizzaPrefabs;
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
    }

    void Movement()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
    }
}
