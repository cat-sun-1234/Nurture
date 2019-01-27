using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    private Slider meter_sld;
    private Transform plant_tr;
    private Animator plant_anit;

    private float growth = 0f;
    private float wilt = 0f;

    public float waterLevel = 20f;

    private float mouseX = -1f;
    private float mouseY = -1f;
    private float diffX = -1f;
    private float diffY = -1f;

    private float touchDX = -1f;
    private float touchDY = -1f;

    private bool wilted = false;
    private float restartCountdown = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        meter_sld = water_meter.GetComponent<Slider>();
        plant_tr = plant.GetComponent<Transform>();

        plant_anit = plant.GetComponent<Animator>();
        
    }

    public void CheckGrowthThresholds()
    {
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

    // Update is called once per frame
    void Update()
    {
        // GAME OVER
        if (wilted)
        {
            restartCountdown -= Time.deltaTime;

            if (restartCountdown <= 0f)
            {
                SceneManager.LoadScene("SelectionScene");
            }
        }

        energy = 1 + ((int)Mathf.Clamp(DayNightCycle.GetSunHeight(), 0, int.MaxValue) / 2);

        if (Input.touchCount > 0 && EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
        {
            Touch touch = Input.GetTouch(0);

            //Update the Text on the screen depending on current position of the touch each frame
            print("Touch Position : " + touch.position);

            waterLevel += fastGrow;
            if (meter_sld.value < 99f)
            {
                // Too slow for my patience, disabling this system for now. -David
                growth += fastGrow; //* energy *Time.deltaTime;
                CheckGrowthThresholds();
            }
        } 
        else if (Input.GetMouseButton(0) && EventSystem.current.IsPointerOverGameObject())
        {
            waterLevel += fastGrow;
            if (meter_sld.value < 99f)
            {
                growth += fastGrow;// *energy*Time.deltaTime;
                CheckGrowthThresholds();
            }
        } else {
            if (meter_sld.value > 0f)
            {
                waterLevel -= slowGrow;
                growth += slowGrow;// *energy*Time.deltaTime;
                CheckGrowthThresholds();
            }
        }

        if (waterLevel >= meter_sld.maxValue)
        {
            meter_sld.value = meter_sld.maxValue;
        }
        else
        {
            meter_sld.value = waterLevel;
        }

        if (waterLevel < 1f || waterLevel >= meter_sld.maxValue)
        {
            wilt += 0.1f;
        } else if (wilt > 0f) {
            wilt -= 0.2f;
        }

        if (wilt > wilt3)
        {
            plant_anit.SetInteger("Wilt", 3);
            wilted = true;
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

        print(growth + " " + wilt);

        if (Input.GetMouseButton(0))
        {
            if (mouseX != -1f && mouseY != -1f) {

                diffX = Input.mousePosition.x - mouseX;
                diffY = Input.mousePosition.y - mouseY;
            }

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


    public void SetPlant(GameObject seed) {
        plant = (GameObject)seed;
        plant_tr = plant.GetComponent<Transform>();
        plant_anit = plant.GetComponent<Animator>();
    }
}
