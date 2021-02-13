using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Globalization;

public class GameManagerScript : MonoBehaviour
{
    public string filePath = "log.txt";

    // Start is called before the first frame update
    void Start()
    {
        CreateFile();

        // Writes time of start to the file
        DateTime time = DateTime.Now;
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            writer.WriteLine("Started at " + time.ToString() + ".");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // If space key is pressed, gets logged in the text file with date and time
        if (Input.GetKeyDown("space"))
        {
            DateTime time = DateTime.Now;
            AppendFile("The space key was pressed at " + time.ToString() + ".");
        }
    }

    // When closed, writes time that the application was quit to file
    void OnApplicationQuit()
    {
        DateTime time = DateTime.Now;
        AppendFile("Quit at " + time.ToString() + ".");
    }

    // Creates new text file if not present
    private void CreateFile()
    {
        if (!File.Exists(filePath))
        {
            File.Create(filePath).Close();
        }
    }

    // Appends text to to created file
    private void AppendFile(string text)
    {
        using(StreamWriter writer = File.AppendText(filePath))
        {
            writer.WriteLine(text);
        }
    }

    // If the button is pressed, gets logged in the text file with date and time
    public void ButtonPressed()
    {
        DateTime time = DateTime.Now;
        AppendFile("Button pressed at " + time.ToString() + ".");
    }
}
