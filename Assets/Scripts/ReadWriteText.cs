using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ReadWriteText : MonoBehaviour
{
    public Text log;
    public InputField fileContent;

    static string filename = "testfile.txt";

    // Start is called before the first frame update
    void Start()
    {
        log.text = "App started @ " + DateTime.Now;

        // look for file on disk
        try
        {
            if (File.Exists(Application.persistentDataPath + "/" + filename))
            {
                log.text += "\nFound file on disk, last saved @ " + File.GetLastWriteTime(Application.persistentDataPath + "/" + filename);
            } else {
                log.text += "\nNo file found file on disk.";
            }
        }
        catch (IOException e)
        {
            Debug.Log("IOException: "+ e.ToString());
        }
    }

    public void WriteFile() 
    {
        StreamWriter writer = new StreamWriter(Application.persistentDataPath + "/" + filename);
        writer.Write(fileContent.text);
        writer.Close();

        log.text += "\nWrote file to disk @ " + DateTime.Now;
        Debug.Log("Wrote file to disk @ " + DateTime.Now);

    }

    public void ReadFile()
    {
        try 
        {
            StreamReader reader = new StreamReader(Application.persistentDataPath + "/" + filename);
            fileContent.text = reader.ReadToEnd();
            reader.Close();

            log.text += "\nRead file @ " + DateTime.Now;
            Debug.Log("Read file @ " + DateTime.Now);
        }
        catch 
        {
            log.text += "\nNo file on disk!";
            Debug.Log("No file on disk!");
        }
    }

    public void DeleteFile()
    {
        try
        {
            if (File.Exists(Application.persistentDataPath + "/" + filename))
            {
                File.Delete(Application.persistentDataPath + "/" + filename);
                log.text += "\nFile deleted.";
            }
            else
            {
                log.text += "\nCan't delete, no file on disk.";
            }
        }
        catch (IOException e)
        {
            Debug.Log("IOException: " + e.ToString());
        }
    }    

}
