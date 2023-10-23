using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoyOutOfBounds : MonoBehaviour
{
    
    private float _topBound = 30f;
    private float _rightBound = 24f;

    private float _downBound = -10f;
    public GameObject hunterBar;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > _topBound)
        {
            Destroy(hunterBar);
            Destroy(gameObject);
        }
        else if (transform.position.z < _downBound)
        {
            Destroy(hunterBar);

            Destroy(gameObject);
        }

        if (transform.position.x > _rightBound)
        {
            Destroy(hunterBar);

            Destroy(gameObject);
        }
        else if (transform.position.x < -_rightBound)
        {
            Destroy(hunterBar);

            Destroy(gameObject);
        }
    }
}