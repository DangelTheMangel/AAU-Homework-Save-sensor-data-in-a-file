using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CSVWriter : MonoBehaviour
{

    //variables
    public string fileName = "data";
    public string[] headers;
    public UnityEngine.UI.InputField filenameInput;
    public int timePrinted = 0;
    // Start is called before the first frame update
    void Start()
    {
        filenameInput.text = fileName; 
    }

    /// <summary>
    /// This function is run under the setup tap if you change the text in the textbox
    /// </summary>
    public void updateFilename() {
        changeFileName(filenameInput.text);
    }

    /// <summary>
    /// this function changes the csv filename to Application.persistentDataPath/input(timeprinted).csv
    /// </summary>
    /// <param name="s"></param>
    public void changeFileName(string s) {
        fileName = Application.persistentDataPath + "/" + s+ "(" +timePrinted+")" +".csv";
    }

    /// <summary>
    /// this function takes the gyro data and make a sting that is given to WriteCSV function
    /// </summary>
    /// <param name="data"></param>
    public void writeCSVFromData(List<SensorData> data) {
        for (int i = 0; i < data.Count; i++) {
            Vector3 r = data[i].rotation;
            string input;
            float xValue = r.x;
            float yValue = r.y;
            float zValue = r.z;
            string timeValue = data[i].time;
            input = xValue + "," + yValue + "," + zValue + "," + timeValue;
            WriteCSV(input);
        }
    }

    /// <summary>
    /// This function check if the file exit and if 
    /// i dont create one with the headers 
    /// from the headers array
    /// </summary>
    /// <param name="input"></param>
    public void WriteCSV(string input)
    {
        // TextWriter klassen skal bruges
        TextWriter tw;
        // Tjekker at der er en fil med det navn
        if (!File.Exists(fileName))
        {
            // tw indstilles til StreamWriter og til overwriting
            tw = new StreamWriter(fileName, false);
            // Skriver en linje med de to værdier der skal tilføjes
            string header = headers[0];
            for (int i = 1; i < headers.Length; i++) {
                header += ","+headers[i];
            }
                
            tw.WriteLine(header);
            // Derefter lukkes den
            tw.Close();
        }
        //skriver en linje i csv filen
        writeCSVLine(input);
    }
    /// <summary>
    /// write a line in the chosen csv file
    /// </summary>
    /// <param name="input"></param>
    void writeCSVLine(string input) {
        // TextWriter klassen skal bruges
        TextWriter tw;
        // tw indstilles til StreamWriter og til appending
        tw = new StreamWriter(fileName, true);
        // tw tilføjer en linje med input
        tw.WriteLine(input);
        // Derefter lukkes den igen
        tw.Close();
    }
}
