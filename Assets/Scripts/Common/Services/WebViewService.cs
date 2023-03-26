using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class WebViewService : MonoBehaviour
{
    private WebViewPluginController controller;
   private void Awake() 
   {
        
       controller = new WebViewPluginController();
   }
   public void ShowVebView(string URL) 
    {
        controller.OpenWebView(URL, 145);
    }
   public void HideVebView() 
    {
        controller.CloseWebView();
    }
}
