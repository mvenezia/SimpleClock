using System;
using UnityEngine;

public class Clock : MonoBehaviour
{
    public bool continuous;

    [SerializeField] private Transform
        hourTransform,
        minuteTransform,
        secondTransform;

    private const float
        degreesPerHour = 30f,
        degreesPerMinute = 6f,
        degreesPerSecond = 6f;

    private void Update()
    {
        UpdateTime(continuous);
    }

    private void UpdateTime(bool updateContinuous)
    {
        if (updateContinuous)
            UpdateTimeContinuous();
        else
            UpdateTimeDiscrete();
    }

    private void UpdateTimeDiscrete()
    {
        Debug.Log(DateTime.Now);
        DateTime time = DateTime.Now;
        hourTransform.localRotation = Quaternion.Euler(0f, time.Hour * degreesPerHour, 0f);
        minuteTransform.localRotation = Quaternion.Euler(0f, time.Minute * degreesPerMinute, 0f);
        secondTransform.localRotation = Quaternion.Euler(0f, time.Second * degreesPerSecond, 0f);
    }

    private void UpdateTimeContinuous()
    {
        Debug.Log(DateTime.Now.TimeOfDay);
        TimeSpan time = DateTime.Now.TimeOfDay;
        hourTransform.localRotation = Quaternion.Euler(0f, (float) time.TotalHours * degreesPerHour, 0f);
        minuteTransform.localRotation = Quaternion.Euler(0f, (float) time.TotalMinutes * degreesPerMinute, 0f);
        secondTransform.localRotation = Quaternion.Euler(0f, (float) time.TotalSeconds * degreesPerSecond, 0f);
    }
}