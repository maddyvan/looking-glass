using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class WeatherProvider : MonoBehaviour
{
    public WeatherInfo weatherInfo;

    private string apiAccessKey = "7606f91593b01bb96762d82232b25380";
    private string locationQuery = "02120";
    private string unitParameter = "f"; // f: Fahrenheit, m: Metric, s: Scientific 

    void Start()
    {
        StartCoroutine(GetWeatherData());
    }

    private IEnumerator GetWeatherData()
    {

        var www = new UnityWebRequest("HTTP://api.weatherstack.com/current?access_key=" + apiAccessKey + "&query=" + locationQuery + "&units=" + unitParameter)
        {
            downloadHandler = new DownloadHandlerBuffer()
        };

        yield return www.SendWebRequest();


        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
            yield break;
        }

        weatherInfo = JsonUtility.FromJson<WeatherInfo>(www.downloadHandler.text);
    }
}

[Serializable]
public class WeatherInfo
{
    public Request request;
    public Location location;
    public Current current;
}

[Serializable]
public class Request
{
    public string type;
    public string query;
    public string language;
    public string unit;
}

[Serializable]
public class Location
{
    public string name;
    public string country;
    public string region;
    public string lat;
    public string lon;
    public string timezone_id;
    public string localtime;
    public float localtime_epoc;
    public string utc_offset;
}

[Serializable]
public class Current
{
    public string observation_time;
    public int temperature;
    public int weather_code;
    public string[] weather_icons;
    public string[] weather_descriptions;
    public int wind_speed;
    public int wind_degree;
    public string wind_dir;
    public int pressure;
    public int precip;
    public int humidity;
    public int cloudcover;
    public int feelslike;
    public int uv_index;
    public int visibility;
    public string is_day;
}