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
    public Volume zone3Volume;

    public float speed = 1f;


    private Boolean flag1 = false;
    private Boolean flag2 = false;
    private Boolean flag3 = false;

    private float timer1 = 0f;
    private float timer2 = 0f;
    private float timer3 = 0f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            if (gameObject.CompareTag("Zone1"))
            {
                flag1 = true;
            }
        }
        if (other.CompareTag("MainCamera"))
        {
            if (gameObject.CompareTag("Zone2"))
            {
                flag2 = true;
            }
        }
        if (other.CompareTag("MainCamera"))
        {
            if (gameObject.CompareTag("Zone3"))
            {
                flag3 = true;
            }
        }
        Debug.Log(flag2);
        Debug.Log(flag1);
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            if (gameObject.CompareTag("Zone1"))
            {
                flag1 = false;
            }
        }
        if (other.CompareTag("MainCamera"))
        {
            if (gameObject.CompareTag("Zone2"))
            {
                flag2 = false;
            }
        }
        if (other.CompareTag("MainCamera"))
        {
            if (gameObject.CompareTag("Zone3"))
            {
                flag3 = false;
            }
        }
    }
    void Update()
    {

        if (flag1)
        {
            if (timer1< speed)
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
            if (timer2 < speed)
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
        if (flag3)
        {
            if (timer3 < speed)
            {
                timer3 += Time.deltaTime;
                zone3Volume.weight = Mathf.Lerp(0, 1, timer3);
            }
        }
        else
        {
            if (timer3 > 0)
            {
                timer3 -= Time.deltaTime;
                zone3Volume.weight = Mathf.Lerp(0, 1, timer3);
            }
        }
    }
    
}
