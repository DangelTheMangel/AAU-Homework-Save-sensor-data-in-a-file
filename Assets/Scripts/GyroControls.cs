using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//inspired from: https://www.youtube.com/watch?v=P5JxTfCAOXo&ab_channel=N3KEN
/// <summary>
/// this class take get the gyro data
/// </summary>
public class GyroControls : MonoBehaviour
{
    private bool gyroEnable = false;
    private Gyroscope gyro;
    public GameObject Object;
    // Start is called before the first frame update
    void Start()
    {
        gyroEnable = enableGyro();
    }

    private bool enableGyro() {
        if (SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro;
            gyro.enabled = true;
            return gyro.enabled;
        }
        else {
            return false;
        }
    }
    /// <summary>
    /// get the instance gyro
    /// </summary>
    /// <returns></returns>
    public Gyroscope getGyro() {
        return gyro;
    }
    /// <summary>
    /// return if gyro have been enable
    /// </summary>
    /// <returns></returns>
    public bool areGyroEnable() {
        return gyroEnable;
    }
}
