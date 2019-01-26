using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WateringController : MonoBehaviour
{
    float energy;

    public GameObject water_meter;
    public GameObject plant;

    //private Transform tr;

    private Transform meter_tr;
    private Transform plant_tr;

    // Start is called before the first frame update
    void Start()
    {
        //tr = GetComponent<Transform> ();

        meter_tr = water_meter.GetComponent<Transform>();
        plant_tr = plant.GetComponent<Transform>();
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

            meter_tr.localScale += new Vector3(0, 0.003f, 0) * energy;
            plant_tr.position += new Vector3(0, 0.001f, 0) * energy;
        }
        else if (Input.GetMouseButton(0) && EventSystem.current.IsPointerOverGameObject())
        {
            print("Pressed left click.");

            meter_tr.localScale += new Vector3(0, 0.003f, 0) * energy;
            plant_tr.position += new Vector3(0, 0.001f, 0) * energy;
        }
        else
        {
            if (meter_tr.localScale.y > 0f)
            {
                meter_tr.localScale -= new Vector3(0, 0.0005f, 0);
                plant_tr.position += new Vector3(0, 0.001f, 0);
            }
        }


    }
}
