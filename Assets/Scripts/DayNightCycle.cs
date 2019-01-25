using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    float timeOfDay;
    int days = 1;
    public float dayLength;
    //bool morning;
    public float SunSetPoint;
    public float timeSpeed;

    public Renderer display;

    public Color day;
    public Color sunset;
    public Color night;

    void Update()
    {
        timeOfDay += Time.deltaTime;
        Transition();
        if (timeOfDay >= dayLength)
        {
            timeOfDay = 0;
            days++;
        }
        Debug.Log(days + " " + (int)timeOfDay);
    }
    void Transition()
    {
        //if(morning)
        //{
        if (timeOfDay < dayLength / 4)
        {
            display.material.color = Color.Lerp(night, sunset, (timeOfDay * 4) / dayLength);
        }
        else if (timeOfDay < 2 * dayLength / 4)
        {
            display.material.color = Color.Lerp(sunset, day, ((timeOfDay * 4) - dayLength) / dayLength);
        }
        else if (timeOfDay < 3 * dayLength / 4)
        {
            display.material.color = Color.Lerp(day, sunset, ((timeOfDay * 4) - (dayLength * 2)) / dayLength);
        }
        else
        {
            display.material.color = Color.Lerp(sunset, night, ((timeOfDay * 4) - (dayLength * 3)) / dayLength);
        }
        //}
    }
}
