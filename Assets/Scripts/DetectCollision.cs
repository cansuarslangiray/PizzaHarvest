using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DetectCollision : MonoBehaviour
{
    public float gainFood;
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
            if (gameObject.tag.Equals("Pizza"))
            {
                Destroy(gameObject);
                if (hunterBar.gameObject != null)
                {
                    var slider = hunterBarImg.transform.GetChild(0).GetComponent<Slider>();
                    if ( slider.value<=0)
                    {
                        hunterBarImg.SetDamage(damage);
                    }
                    else if (slider.value >=3)
                    {
                        GameManager.Score += 1f;
                        // Destroy(hunterBarImg.GetComponent<GameObject>());
                        Destroy(other.gameObject);
                    }
                }
            }
        }
    }
}