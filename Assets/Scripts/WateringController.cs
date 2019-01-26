using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class WateringController : MonoBehaviour
{
    public float energy;

    public GameObject water_meter;
    public GameObject plant;

    //private Transform tr;

    public float waterAdd = 0.3f; //measures how much water is added to meter per tick
    public float waterDeplete = 0.01f; //rate at which the water depletes over time
    private Slider meter_sld;
    private Transform plant_tr;

    // Start is called before the first frame update
    void Start()
    {
        //tr = GetComponent<Transform> ();

        meter_sld = water_meter.GetComponent<Slider>();
        plant_tr = plant.GetComponent<Transform>();
        meter_sld.value = plant.GetComponent<Plant>().waterLevel;
    }

    // Update is called once per frame
    void Update()
    {
        energy = 1 + ((int)Mathf.Clamp(DayNightCycle.GetSunHeight(), 0, int.MaxValue) / 2);

        if (Input.touchCount > 0 && EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
        {
            Touch touch = Input.GetTouch(0);

            //Update the Text on the screen depending on current position of the touch each frame
            print("Touch Position : " + touch.position);

            //meter_tr.localScale += new Vector3(0, 0.003f, 0);
            if (meter_sld.value < meter_sld.maxValue)
            {
                plant.GetComponent<Plant>().waterLevel += waterAdd;
            }
            if (meter_sld.value < 99f && plant_tr.position.y < -1.3f)
            {
                plant_tr.position += new Vector3(0, plant.GetComponent<Plant>().growthRate*energy, 0);
            }
        } 
        else if (Input.GetMouseButton(0) && EventSystem.current.IsPointerOverGameObject())
        {
            print("Pressed left click.");

            //meter_tr.localScale += new Vector3(0, 0.003f, 0);
            if (meter_sld.value < meter_sld.maxValue)
            {
                plant.GetComponent<Plant>().waterLevel += waterAdd;
            }
            if (meter_sld.value < 99f && plant_tr.position.y < -1.3f)
            {
                plant_tr.position += new Vector3(0, plant.GetComponent<Plant>().growthRate * energy, 0); //growth now affected bu energy from sun
            }
        } else {
            if (meter_sld.value > 0f)
            {
                //meter_tr.localScale -= new Vector3(0, 0.0005f, 0);
                plant.GetComponent<Plant>().waterLevel -= waterDeplete*energy; //let's have depletion affected by energy too, more sun = more heat = more drying up
                if (plant_tr.position.y < -1.3f)
                {
                    plant_tr.position += new Vector3(0, plant.GetComponent<Plant>().growthRate * energy, 0);
                }
            }
        }
        meter_sld.value = plant.GetComponent<Plant>().waterLevel;
    }


}
