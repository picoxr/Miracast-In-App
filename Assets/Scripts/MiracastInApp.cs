using System.Collections;
using System.Collections.Generic;
using Unity.XR.PXR;
using UnityEngine;
using UnityEngine.UI;
using LitJson;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;

public class MiracastInApp : MonoBehaviour
{
    public Text reminder;
    public Text[] deviceName;


    private bool selectDevice = false;
    private bool isMiracastOn = false;
    private string modelJson;
    public List<string> content = new List<string>();

    public void OpenMiracast()
    {
        PXR_System.OpenMiracast();
        isMiracastOn = PXR_System.IsMiracastOn();
        if (isMiracastOn)
        {
            reminder.color = Color.red;
            reminder.text = "Open success";
        }
        else
        {
            reminder.text = "Open failed";
        }
    }
    public void StartScan()
    {



        if (isMiracastOn)
        {
            PXR_System.StartScan();

            Debug.Log("Mircast ON!");
            PXR_System.SetWDJsonCallback();
            PXR_System.UpdateWifiDisplays(parsejsonfile);
            reminder.text = "Select the device";
        }
        else
        {
            Debug.Log("Mircast OFF!");
            reminder.text = " Please turn on the screencast function";
        }
    }



    public void StartProjection()
    {
        if (selectDevice && isMiracastOn)
        {
            PXR_System.ConnectWifiDisplay(modelJson);

        }
        else
        {
            reminder.text = "Please turn on the screencast function and select the device first";
        }
    }

    public void StopProjection()
    {
        PXR_System.DisConnectWifiDisplay();
    }


    public void parsejsonfile(string obj)
    {

        JArray jArray = JArray.Parse(obj);
        for (int i = 0; i < jArray.Count; i++)
        {
            JsonData data = new JsonData();
            JObject job = (JObject)jArray[i];
            string StrdeviceAddress = job["deviceAddress"].ToString();
            string StrdeviceName = job["deviceName"].ToString();
            string StrisAvailable = job["isAvailable"].ToString();
            string StrcanConnect = job["canConnect"].ToString();
            string StrisRemembered = job["isRemembered"].ToString();
            string StrstatusCode = job["statusCode"].ToString();  

            if (i < 5)
            {
                deviceName[i].text = StrdeviceName;
                data["deviceAddress"] = StrdeviceAddress;
                data["deviceName"] = StrdeviceName;
                data["isAvailable"] = StrisAvailable;
                data["canConnect"] = StrcanConnect;
                data["isRemembered"] = StrisRemembered;
                data["statusCode"] = StrstatusCode;
                data["status"] = "";
                data["description"] = "";
                string json = data.ToJson();
                content[i] = json;
                Debug.Log("content:" + content[i]);
            }

        }

    }

    public void deviceBtn1()
    {
        selectDevice = true;
        modelJson = content[0];
        reminder.text = deviceName[0].text;

    }
    public void deviceBtn2()
    {
        selectDevice = true;
        modelJson = content[1];
        reminder.text = deviceName[1].text;

    }
    public void deviceBtn3()
    {
        selectDevice = true;
        modelJson = content[2];
        reminder.text = deviceName[2].text;

    }
    public void deviceBtn4()
    {
        selectDevice = true;
        modelJson = content[3];
        reminder.text = deviceName[3].text;

    }
    public void deviceBtn5()
    {
        selectDevice = true;
        modelJson = content[4];
        reminder.text = deviceName[4].text;

    }

    public void closeMiracast()
    {
        PXR_System.CloseMiracast();
        isMiracastOn = PXR_System.IsMiracastOn();
        if (isMiracastOn == false)
        {
            reminder.text = "Close success";
        }
        else
        {
            reminder.text = "Close failed";
        }

    }
}
