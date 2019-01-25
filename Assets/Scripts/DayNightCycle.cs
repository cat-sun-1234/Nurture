using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    float timeOfDay;
    int days = 1;
    public float dayLength;
    //bool morning;
    [Header("Sun")]
    public GameObject sun;
    public AnimationCurve sunXPos;
    public AnimationCurve sunYPos;
    public float sunBottom;
    public float sunTop;
    [Header("Sky")]
    [Range(0, 0.5f)]
    public float sunSetPoint;
    [Range(0, 0.25f)]
    public float sunSetStartLength;
    [Range(0, 0.25f)]
    public float sunSetEndLength;
    public float timeSpeed;

    public SpriteRenderer sky;


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
        float time = timeOfDay / dayLength;
        #region Sun Position
        float sunX = ((sunXPos.Evaluate(time) * ((sunTop + sunBottom) / 2)) - ((sunTop + sunBottom) / 4));
        float sunY = ((sunYPos.Evaluate(time) * sunTop) - sunBottom);
        sun.transform.position = (Vector3.right * sunX) + (Vector3.up * sunY);
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
        #endregion
        //}
    }
}
