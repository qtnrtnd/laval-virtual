using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UIElements;

public class ManageCameraFilter : MonoBehaviour
{
    public Volume zone1Volume;
    public Volume zone2Volume;
    public float speed = 0.1f;

    private Coroutine transitionCoroutine;
    private Coroutine testCoroutine;

    private Boolean flag1 = false;
    private Boolean flag2 = false;

    private float timer1 = 0f;
    private float timer2 = 0f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (gameObject.CompareTag("Zone1"))
            {
                flag1 = true;
            }
        }
        if (other.CompareTag("Player"))
        {
            if (gameObject.CompareTag("Zone2"))
            {
                flag2 = true;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (gameObject.CompareTag("Zone1"))
            {
                flag1 = false;
            }
        }
        if (other.CompareTag("Player"))
        {
            if (gameObject.CompareTag("Zone2"))
            {
                flag2 = false;
            }
        }
    }
    void Update()
    {
        if (flag1)
        {
            if (timer1<1f)
            {
                timer1 += Time.deltaTime;
                zone1Volume.weight = Mathf.Lerp(0, 1, timer1);
            }
        }
        else
        {
            if (timer1>0)
            {
                timer1 -= Time.deltaTime;
                zone1Volume.weight = Mathf.Lerp(0, 1, timer1);
            }
        }
        if (flag2)
        {
            if (timer2 < 1f)
            {
                timer2 += Time.deltaTime;
                zone2Volume.weight = Mathf.Lerp(0, 1, timer2);
            }
        }
        else
        {
            if (timer2 > 0)
            {
                timer2 -= Time.deltaTime;
                zone2Volume.weight = Mathf.Lerp(0, 1, timer2);
            }
        }
    }
    
}
