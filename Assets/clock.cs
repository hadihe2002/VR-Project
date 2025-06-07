using System;
using UnityEngine;

public class clock : MonoBehaviour
{
    public GameObject hour;
    public GameObject minute;
    public GameObject second;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        DateTime currentTime = DateTime.Now;

        float hourRotation = (currentTime.Hour % 12 + currentTime.Minute / 60f) * 30f; // 360 degrees / 12 hours = 30 degrees per hour
        float minuteRotation = (currentTime.Minute + currentTime.Second / 60f) * 6f; // 360 degrees / 60 minutes = 6 degrees per minute
        float secondRotation = currentTime.Second * 6f; // 360 degrees / 60 seconds = 6 degrees per second

        hour.transform.eulerAngles = new Vector3(hourRotation, -180, 0);
        minute.transform.eulerAngles = new Vector3(minuteRotation, -180, 0);
        second.transform.eulerAngles = new Vector3(secondRotation, -180, 0);
    }
}
