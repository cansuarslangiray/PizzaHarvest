using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("hitt");
        GameManager.Score +=0.5f;
        Destroy(gameObject);
        Destroy(other.gameObject);
    }
}
