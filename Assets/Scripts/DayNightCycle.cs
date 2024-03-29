﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    public float timeSpeed;
    [Range(0,1)]
    public float startTime;
    float timeOfDay;
    int days = 1;
    public float dayLength;
    //bool morning;
    [Header("Sun")]
    public GameObject sun;
    static float sunHeight;
    public AnimationCurve sunXPos;
    public AnimationCurve sunYPos;
    public float sunCentrePoint;
    public float sunRadius;
    [Header("Moon")]
    public GameObject moon;
    float moonHeight;
    public AnimationCurve moonXPos;
    public AnimationCurve moonYPos;
    public float moonCentrePoint;
    public float moonRadius;
    [Header("Sky")]
    public SpriteRenderer sky;
    [Header("0 is Midnight, 0.5 is midday")]
    [Range(0, 0.5f)]
    public float sunSetPoint;
    [Range(0, 0.25f)]
    public float sunSetStartLength;
    [Range(0, 0.25f)]
    public float sunSetEndLength;
    public Color day;
    public Color sunset;
    public Color night;
    private void Awake()
    {
        timeOfDay = startTime * dayLength;
    }
    void Update()
    {
        timeOfDay += Time.deltaTime;
        Transition();
        if (timeOfDay >= dayLength)
        {
            timeOfDay = 0;
            days++;
        }
        //Debug.Log(days + " " + (int)timeOfDay);
    }
    public static float GetSunHeight()
    {
        return sunHeight;
    }
    void Transition()
    {
        float time = timeOfDay / dayLength;
        #region Sun Position
        float sunX = ((sunXPos.Evaluate(time) * 2) - 1) * sunRadius;
        sunHeight = ((sunYPos.Evaluate(time) * 2) - 1) * sunRadius;
        sun.transform.position = (Vector3.right * sunX) + (Vector3.up * (sunHeight + sunCentrePoint));
        #endregion
        #region Moon Position
        float moonX = ((moonXPos.Evaluate(time) * 2) - 1) * moonRadius;
        moonHeight = ((moonYPos.Evaluate(time) * 2) - 1) * moonRadius;
        moon.transform.position = (Vector3.right * moonX) + (Vector3.up * (moonHeight + moonCentrePoint));
        #endregion
        #region Sky Color
        if (time > sunSetPoint && time < (sunSetPoint + sunSetStartLength))
        {
            float p = Mathf.InverseLerp(sunSetPoint, sunSetPoint + sunSetStartLength, time);
            sky.color = Color.Lerp(night, sunset, p);
        }
        else if (time > (sunSetPoint + sunSetStartLength) && time < (sunSetPoint + sunSetStartLength + sunSetEndLength))
        {
            float p = Mathf.InverseLerp((sunSetPoint + sunSetStartLength), (sunSetPoint + sunSetStartLength + sunSetEndLength), time);
            sky.color = Color.Lerp(sunset, day, p);
        }
        else if (time > 1 - (sunSetPoint + sunSetStartLength + sunSetEndLength) && time < 1 - (sunSetPoint + sunSetStartLength))
        {
            float p = Mathf.InverseLerp(1 - (sunSetPoint + sunSetStartLength + sunSetEndLength), 1 - (sunSetPoint + sunSetStartLength), time);
            sky.color = Color.Lerp(day, sunset, p);
        }
        else if (time > 1 - (sunSetPoint + sunSetStartLength) && time < 1 - sunSetPoint)
        {
            float p = Mathf.InverseLerp(1 - (sunSetPoint + sunSetStartLength), 1 - sunSetPoint, time);
            sky.color = Color.Lerp(sunset, night, p);
        }
        else if(time < sunSetPoint || time > 1 - sunSetPoint)
        {
            sky.color = night;
        }
        else if (time > (sunSetPoint + sunSetStartLength + sunSetEndLength) || time < 1 - (sunSetPoint + sunSetStartLength + sunSetEndLength))
        {
            sky.color = day;
        }
        #endregion
        //}
    }
}
