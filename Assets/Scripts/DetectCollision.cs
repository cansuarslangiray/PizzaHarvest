using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DetectCollision : MonoBehaviour
{
    public float damage;

    public GameObject hunterBar;

    private HunterBar hunterBarImg;

    // Start is called before the first frame update
    void Start()
    {
        if (!gameObject.tag.Equals("Player") && !gameObject.tag.Equals("Pizza"))
        {
            var bar = Instantiate(hunterBar, transform.position, Quaternion.identity);
            hunterBarImg = bar.GetComponent<HunterBar>();
            Debug.Log(hunterBarImg.name);
            GetComponent<DestoyOutOfBounds>().hunterBar = bar;

        }
    }

    private void Update()
    {
        if (!gameObject.tag.Equals("Player") && !gameObject.tag.Equals("Pizza"))
        {
            hunterBarImg.SetPositionFill(transform.position);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.tag.Equals("Player"))
        {
            if (other.tag.Equals("Pizza"))
            {
                Destroy(other.gameObject);
                if (hunterBar.gameObject != null)
                {
                    Debug.Log(hunterBarImg.name);
                    var slider = hunterBarImg.slide;
                    hunterBarImg.SetDamage(damage);
                    
                    if (slider.value >=3)
                    {
                        GameManager.Score += 1f;
                        Destroy(hunterBarImg.gameObject);
                        Destroy(gameObject);
                    }
                }
            }
        }
    }
}