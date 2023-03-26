using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ViewModels
{
    public class VideoViewModel : BaseViewModel
    {
        private const string StartURL = "https://learnenglish.britishcouncil.org/general-english/video-zone";
        WebViewService _webViewService;
        public VideoViewModel(WebViewService webViewService) 
        {
            _webViewService = webViewService;
        }
        public override void Show()
        {
            base.Show();
            ShowWeb();
        }
        public override void Hide()
        {
            base.Hide();
            _webViewService.HideVebView();
        }
        private void ShowWeb()
        {
            _webViewService.ShowVebView(StartURL);
        }
    }
}