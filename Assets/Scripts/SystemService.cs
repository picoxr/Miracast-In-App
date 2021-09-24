using System.Collections;
using System.Collections.Generic;
using Unity.XR.PXR;
using UnityEngine;
using UnityEngine.UI;

public class SystemService: MonoBehaviour
{
    //public string data;
    
    //初始化并绑定Service，其中objectName为接收回调的脚本物体名称
    private void Awake()
    {
        PXR_System.InitSystemService(this.name);
        PXR_System.BindSystemService();
        
    }
    //解除绑定Service
    private void OnDestory()
    {
        PXR_System.UnBindSystemService();
    }
    //增加4个接收回调方法
    private void BoolCallback(string value)
    {
        if (PXR_Plugin.System.BoolCallback != null) PXR_Plugin.System.BoolCallback(bool.Parse(value));
        PXR_Plugin.System.BoolCallback = null;
    }
    private void IntCallback(string value)
    {
        if (PXR_Plugin.System.IntCallback != null) PXR_Plugin.System.IntCallback(int.Parse(value));
        PXR_Plugin.System.IntCallback = null;
    }
    private void LongCallback(string value)
    {
        if (PXR_Plugin.System.LongCallback != null) PXR_Plugin.System.LongCallback(int.Parse(value));
        PXR_Plugin.System.LongCallback = null;
    }
    private void StringCallback(string value)
    {
        if (PXR_Plugin.System.StringCallback != null) PXR_Plugin.System.StringCallback(value);
        PXR_Plugin.System.StringCallback = null;
    }
    public void toBServiceBind(string s) { Debug.Log("Bind success."); }
}
