using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
//inspired from: https://www.youtube.com/watch?v=P5JxTfCAOXo&ab_channel=N3KEN
/// <summary>
/// this class take get the gyro data
/// </summary>
public class GyroControls : MonoBehaviour
{
    UnityEngine.InputSystem.Gyroscope gyro;
    SensorControlls sensorControlls;

    private void Awake()
    {
        sensorControlls = new SensorControlls();
    }
    private void Start()
    {
        InputSystem.EnableDevice(UnityEngine.InputSystem.Gyroscope.current);
        sensorControlls.Default.Enable();


    }

    public Vector3 readValue() {
        return sensorControlls.Default.Gyro.ReadValue<Vector3>();
    }
    public bool isEnable() {
        return UnityEngine.InputSystem.Gyroscope.current.enabled;
    }
}
