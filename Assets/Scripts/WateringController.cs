using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class WateringController : MonoBehaviour
{
    float energy;

    public GameObject water_meter;
    public GameObject plant;
    public Text debug;

    [Header("Grow Speed")]
    public float fastGrow = 0.3f;
    public float slowGrow = 0.1f;
    [Header("Plant Growth")]
    public float stage1 = 20f;
    public float stage2 = 40f;
    public float stage3 = 70f;
    public float stage4 = 100f;
    [Header("Plant Wilt")]
    public float wilt1 = 20f;
    public float wilt2 = 40f;
    public float wilt3 = 60f;
    public float recover1 = 10f;
    public float recover2 = 30f;

    //private Transform tr;

    private Slider meter_sld;
    private Transform plant_tr;
    private Animator plant_anit;

    private float growth = 0f;
    private float wilt = 0f;

    private float mouseX = -1f;
    private float mouseY = -1f;
    private float diffX = -1f;
    private float diffY = -1f;

    private float touchDX = -1f;
    private float touchDY = -1f;

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
            meter_sld.value += fastGrow;
            if (meter_sld.value < 99f)
            {
                //plant_tr.position += new Vector3(0, 0.001f, 0);
                growth += fastGrow;
                if (growth > stage1)
                {
                    plant_anit.SetInteger("Growth", 1);
                }
                else if (growth > stage2)
                {
                    plant_anit.SetInteger("Growth", 2);
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
                growth += fastGrow;
                if (growth > stage4)
                {
                    plant_anit.SetInteger("Growth", 4);
                }
                else if (growth > stage3)
                {
                    plant_anit.SetInteger("Growth", 3);
                }
                else if (growth > stage2)
                {
                    plant_anit.SetInteger("Growth", 2);
                }
                else if (growth > stage1)
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
                growth += slowGrow;
                if (growth > stage4)
                {
                    plant_anit.SetInteger("Growth", 4);
                }
                else if (growth > stage3)
                {
                    plant_anit.SetInteger("Growth", 3);
                }
                else if (growth > stage2)
                {
                    plant_anit.SetInteger("Growth", 2);
                }
                else if (growth > stage1)
                {
                    plant_anit.SetInteger("Growth", 1);
                }
            }
        }

        if (meter_sld.value < 1f)
        {
            wilt += 0.1f;
        } else if (wilt > 0f) {
            wilt -= 0.2f;
        }

        if (wilt > wilt3)
        {
            plant_anit.SetInteger("Wilt", 3);
        }
        else if (wilt > wilt2)
        {
            plant_anit.SetInteger("Wilt", 2);
        }
        else if (wilt > wilt1)
        {
            plant_anit.SetInteger("Wilt", 1);
        }
        else if (wilt < recover2 && plant_anit.GetInteger("Wilt") == 2)
        {
            plant_anit.SetInteger("Wilt", 1);
        }
        else if (wilt < recover1 && plant_anit.GetInteger("Wilt") == 1)
        {
            plant_anit.SetInteger("Wilt", 0);
        }
        //print(growth + " wilt: " + wilt);


        if (Input.GetMouseButton(0))
        {
            if (mouseX != -1f && mouseY != -1f) {

                diffX = Input.mousePosition.x - mouseX;
                diffY = Input.mousePosition.y - mouseY;
            }

            //print(diffX + " " + diffY);

            if (diffX < -15f && diffY > -10f && diffY < 10f )
            {
                print("Swiped Left!");
            }
            else if (diffX > 15f && diffY > -10f && diffY < 10f )
            {
                print("Swiped Right!");
            }


            mouseX = Input.mousePosition.x;
            mouseY = Input.mousePosition.y;
        } else {
            mouseX = -1f;
            mouseY = -1f;
            diffX = -1f;
            diffY = -1f;
        }

        if (Input.touchCount > 0)
        {

            Touch touch = Input.GetTouch(0);

            print(touch.deltaPosition.x + " " + touch.deltaPosition.y);


            debug.text = "delta" + touch.deltaPosition.x + " " + touch.deltaPosition.y;

            if (touch.deltaPosition.x < -15f && touch.deltaPosition.y > -10f && touch.deltaPosition.y < 10f )
            {
                debug.text = "delta" + touch.deltaPosition.x + " " + touch.deltaPosition.y + " LEFT";
            }
            else if (touch.deltaPosition.x > 15f && touch.deltaPosition.y > -10f && touch.deltaPosition.y < 10f )
            {
                debug.text = "delta" + touch.deltaPosition.x + " " + touch.deltaPosition.y + " RIGHT";
            }


            //mouseX = Input.mousePosition.x;
            //mouseY = Input.mousePosition.y;
        } else {
            /*mouseX = -1f;
            mouseY = -1f;
            diffX = -1f;
            diffY = -1f;*/
        }

    }
}
