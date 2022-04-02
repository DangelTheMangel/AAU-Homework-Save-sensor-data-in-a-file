using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataCollectorScript : MonoBehaviour
{

    [SerializeField]
    GyroControls gyroControls;
    public float endTime = 3;
    public float timer = 4;
    public CSVWriter csvWriter;
    [SerializeField]
    string buttonTextWhenCollection = "Stop Collection";

    [SerializeField]
    string buttonTextNoCollection = "Collect data";

    [SerializeField]
    Text buttonText;

    public InputField inputField;
    public bool collectingData = false;
    public List<SensorData> dataCollected = new List<SensorData>();
    // Start is called before the first frame update
    void Start()
    {
        inputField.text = endTime.ToString();
        Debug.Log(inputField.name);
        if (endTime <= 0) {
            endTime += 1f;
        }
    }

    /// <summary>
    /// this function is call in the setup tap when you change the time
    /// </summary>
    /// <param name="time"></param>
    public void changeTime(string time) {
        Debug.Log("time " + time);
        bool tryParse = float.TryParse(time, out timer);
        if (tryParse) {
            endTime = float.Parse(time);
            
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (collectingData  && timer < endTime)
        {
            timer += Time.deltaTime;
            SensorData data = new SensorData(gyroControls.readValue());
            dataCollected.Add(data);
        }
        else if(collectingData && timer >= endTime) {
            reset();
        }
    }

    /// <summary>
    /// this test rest the test by clear the datalist,++timePrinted, 
    /// buttonText to the buttonTextNoCollection and collectingData = false
    /// </summary>
    void reset()
    {
        Debug.Log("done");
    
        csvWriter.writeCSVFromData(dataCollected);
        csvWriter.timePrinted += 1;
        csvWriter.updateFilename();
        buttonText.text = buttonTextNoCollection;
        dataCollected.Clear();
        collectingData = false;
    }
    /// <summary>
    /// this function start the test
    /// </summary>
    public void startCollection() {
        collectingData = !collectingData;

        if (collectingData)
        {
            buttonText.text = buttonTextWhenCollection;
            timer = 0;
        }
        else {
            reset();
        }
    }
}


/// <summary>
/// this class have the sensor data and time when it is taken
/// </summary>
[Serializable]
public class SensorData {
    public Vector3 rotation;
    public string time;

    public SensorData(Vector3 rotation) {
        this.rotation = rotation;
        long milliseconds = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
        time = DateTime.Now.ToString() + " m:" + milliseconds.ToString();
    }
}
