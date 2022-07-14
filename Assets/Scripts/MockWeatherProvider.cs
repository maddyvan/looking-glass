using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MockWeatherProvider : MonoBehaviour
{

    private int callCount = 0;
    public int[] temps = { 69, 42, 69};

    public void GetCurrentWeather()
    {
        callCount = (callCount + 1) / temps.Length;
    }

    public string Temperature()
    {
        return temps[callCount].ToString() + "°";
    }
}
