using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class WateringController : MonoBehaviour
{
    public GameObject water_meter;
    public GameObject plant;

    //private Transform tr;

    private Slider meter_sld;
    private Transform plant_tr;

    // Start is called before the first frame update
    void Start()
    {
        //tr = GetComponent<Transform> ();

        meter_sld = water_meter.GetComponent<Slider>();
        plant_tr = plant.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        

        if (Input.touchCount > 0 && EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
        {
            Touch touch = Input.GetTouch(0);

            //Update the Text on the screen depending on current position of the touch each frame
            print("Touch Position : " + touch.position);

            //meter_tr.localScale += new Vector3(0, 0.003f, 0);
            meter_sld.value += 0.3f;
            if (meter_sld.value < 99f && plant_tr.position.y < -1.3f)
            {
                plant_tr.position += new Vector3(0, 0.001f, 0);
            }
        } 
        else if (Input.GetMouseButton(0) && EventSystem.current.IsPointerOverGameObject())
        {
            print("Pressed left click.");

            //meter_tr.localScale += new Vector3(0, 0.003f, 0);
            meter_sld.value += 0.3f;
            if (meter_sld.value < 99f && plant_tr.position.y < -1.3f)
            {
                plant_tr.position += new Vector3(0, 0.001f, 0);
            }
        } else {
            if (meter_sld.value > 0f)
            {
                //meter_tr.localScale -= new Vector3(0, 0.0005f, 0);
                meter_sld.value -= 0.1f;
                if (plant_tr.position.y < -1.3f)
                {
                    plant_tr.position += new Vector3(0, 0.0005f, 0);
                }
            }
        }

        
    }
}
