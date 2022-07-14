using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DigitalClock : MonoBehaviour
{
    public TMPro.TMP_Text time;
    public TMPro.TMP_Text temperature;

    private MockWeatherProvider weatherProvider;
    public float weatherRefreshRate = 0.5f; // in minutes

    void Start()
    {
        weatherProvider = GetComponent<MockWeatherProvider>();
        StartCoroutine(UpdateWather());
    }

    void Update()
    {
        UpdateTime();
    }

    private IEnumerator UpdateWather()
    {
        // Get weather data
        weatherProvider.GetCurrentWeather();

        //
        temperature.text = weatherProvider.Temperature();

        yield return new WaitForSeconds(60 * weatherRefreshRate);
    }

    private void UpdateTime()
    {
        DateTime dateTime = DateTime.Now;

        string hour = AddLeadingZero(dateTime.Hour);
        string minute = AddLeadingZero(dateTime.Minute);
        string second = AddLeadingZero(dateTime.Second);

        time.text = hour + ":" + minute + ":" + second;
    }

    private string AddLeadingZero(int num)
    {
        return num.ToString().PadLeft(2, '0');
    }
}
