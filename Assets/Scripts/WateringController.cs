﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class WateringController : MonoBehaviour
{
    float energy;

    public GameObject water_meter;
    public GameObject plant;

    //private Transform tr;

    private Slider meter_sld;
    private Transform plant_tr;
    private Animator plant_anit;

    private float growth = 0f;

    // Start is called before the first frame update
    void Start()
    {
        //tr = GetComponent<Transform> ();

        meter_sld = water_meter.GetComponent<Slider>();
        plant_tr = plant.GetComponent<Transform>();

        plant_anit = plant.GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        energy = 1 + ((int)Mathf.Clamp(DayNightCycle.GetSunHeight(), 0, int.MaxValue) / 2);

        //plant_anit.speed = 0;

        if (Input.touchCount > 0 && EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
        {
            Touch touch = Input.GetTouch(0);

            //Update the Text on the screen depending on current position of the touch each frame
            print("Touch Position : " + touch.position);

            //meter_tr.localScale += new Vector3(0, 0.003f, 0);
            meter_sld.value += 0.3f;
            if (meter_sld.value < 99f)
            {
                //plant_tr.position += new Vector3(0, 0.001f, 0);
                growth += 0.3f;
                if (growth > 200f)
                {
                    plant_anit.SetInteger("Growth", 1);
                }
            }
        } 
        else if (Input.GetMouseButton(0) && EventSystem.current.IsPointerOverGameObject())
        {

            //meter_tr.localScale += new Vector3(0, 0.003f, 0);
            meter_sld.value += 0.3f;
            if (meter_sld.value < 99f)
            {
                //plant_tr.position += new Vector3(0, 0.001f, 0);
                growth += 0.3f;
                if (growth > 200f)
                {
                    plant_anit.SetInteger("Growth", 1);
                }
            }
        } else {
            if (meter_sld.value > 0f)
            {
                //meter_tr.localScale -= new Vector3(0, 0.0005f, 0);
                meter_sld.value -= 0.1f;
                //plant_tr.position += new Vector3(0, 0.0005f, 0);
                growth += 0.1f;
                if (growth > 200f)
                {
                    plant_anit.SetInteger("Growth", 1);
                }
            }
        }
        print(growth);


    }
}
