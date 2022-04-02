using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// this class update the input display and vissual cube 
/// </summary>
public class visulizerManager : MonoBehaviour
{

    [SerializeField]
    GyroControls gyroControls;
    Quaternion gyroRotation;
    public GameObject visualizeObject;
    public DataCollectorScript dataCollector;
    [SerializeField]
    Text textOutput;
    [SerializeField]
    string outputText1 = "Gyroscope Quaternion:\n";
    [SerializeField]
    string outputText2 = "\nGyroscope Angels:\n";

    [SerializeField]
    string outputText3 = "\nTime:\n";

    [SerializeField]
    string errorMessage = "No Gyroscope was found";


    private void Start()
    {
        textOutput.text = errorMessage;

        
    }
    private void FixedUpdate()
    {
        if (gyroControls != null)
        {
            Vector3 rotationVector = gyroControls.readValue();
            Vector3 realRotationVector = rotationVector * 360;
            Quaternion cubeRoatation = Quaternion.Euler(realRotationVector.x, realRotationVector.y, realRotationVector.z);
            visualizeObject.transform.rotation = cubeRoatation;
            if (dataCollector.collectingData)
            {
                textOutput.text = outputText1 + rotationVector + outputText2 + realRotationVector + outputText3 + (dataCollector.endTime -dataCollector.timer);
            }
            else {
                textOutput.text = outputText1 + rotationVector + outputText2 + cubeRoatation;
            }
        }

    }

    
}
