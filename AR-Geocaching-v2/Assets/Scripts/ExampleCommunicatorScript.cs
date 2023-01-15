/* References: */
//  The Singularity by VR/AR MIT
//      https://github.com/VRatMIT/TheSingularity-Unity
//  The Singularity - Wiki
//      https://github.com/VRatMIT/TheSingularity-Unity/wiki

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sngty;
using TMPro;
using UnityEngine.UI;

public class ExampleCommunicatorScript : MonoBehaviour
{

    public SingularityManager mySingularityManager;

    public TextMeshProUGUI displayText;
    public GameObject hotColdImage;
    public Slider progressBar;

    // Start is called before the first frame update
    void Start()
    {
        displayText.text = "0";

        List<DeviceSignature> pairedDevices = mySingularityManager.GetPairedDevices();
        DeviceSignature myDevice;
        myDevice.name = "placeholder";
        myDevice.mac = "1234556789 placeholder";

        //If you are looking for a device with a specific name (in this case exampleDeviceName):
        for (int i = 0; i < pairedDevices.Count; i++)
        {
            if (pairedDevices[i].name == "geocache")
            {
                myDevice = pairedDevices[i];
                break;
            }
        }

        if (!myDevice.Equals(default(DeviceSignature)))
        {
            //Do stuff to connect to the device here
            mySingularityManager.ConnectToDevice(myDevice);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //KEEP IN MIND IF YOU ARE USING THIS WITH AN ANDROID DEVICE YOU WON'T BE ABLE TO READ LOGS FROM UNITY.
    //You'll have to read the logcat logs through USB debugging. Or just display your messages on a GUI instead of Debug.Log.
    public void onConnected()
    {
        Debug.Log("Connected to device!");
        displayText.text = "Connected to device!";
        hotColdImage.SetActive(true);
    }

    public void onMessageRecieved(string message)
    {
        //Debug.Log("Message recieved from device: " + message);
        //UpdateDisplayText(textToShow);

        if(message.StartsWith("rssi: "))
        {
            string progress_text = "";
            for(int i = 0; i < message.Length; ++i)
            {
                if(i >= 6)
                {
                    progress_text += message[i];
                }
            }
            UpdateDisplayText(progress_text);
            int progress = int.Parse(progress_text);
            progressBar.value = -progress;
        }
    }

    public void onError(string errorMessage)
    {
        Debug.LogError("Error with Singularity: " + errorMessage);
    }

    public void UpdateDisplayText(string message)
    {
        displayText.text = message;
    }
}
