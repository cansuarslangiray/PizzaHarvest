using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HunterBar : MonoBehaviour
{
    public GameObject canvas;
    public Vector3 position;
    public Camera camera;
    public Slider slide;


    private void Start()
    {
        canvas = GameObject.Find("Canvas");
        camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        slide = GetComponent<Slider>();
        transform.SetParent(canvas.transform);
        slide.value = 0;
    }


    public void SetPositionFill(Vector3 pos)
    {
        position = pos;
    }

    public void SetDamage(float fill)
    {
        slide.value += fill;
    }

    private void Update()
    {
        transform.position = camera.WorldToScreenPoint(position);
    }

    private void DestoyHunterBar()
    {
        float _topBound = 30f;
        float _rightBound = 24f;
        float _downBound = -10f;
        Vector3 point = new Vector3();
        point = camera.ScreenToWorldPoint(new Vector3(_rightBound, _topBound, camera.nearClipPlane));
    }

    
}