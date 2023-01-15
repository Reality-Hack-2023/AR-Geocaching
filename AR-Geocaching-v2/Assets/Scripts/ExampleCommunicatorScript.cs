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

public class ExampleCommunicatorScript : MonoBehaviour
{

    public SingularityManager mySingularityManager;

    public TextMeshProUGUI displayText;

    // Start is called before the first frame update
    void Start()
    {
        displayText.text = "PLACEHOLDER";

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
    }

    public void onMessageRecieved(string message)
    {
        //Debug.Log("Message recieved from device: " + message);
        //UpdateDisplayText(textToShow);

        if(message.StartsWith("rssi: "))
        {
            UpdateDisplayText(message);
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
