using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityMvvmToolkit.Core;
namespace ViewModels
{
    public class BaseViewModel : ViewModel
    {

        public event EventHandler OnShow;
        public event EventHandler OnHide;
       


        public void Show() 
        {
            OnShow?.Invoke(this, EventArgs.Empty);
        }
        public void Hide() 
        {
            OnHide?.Invoke(this, EventArgs.Empty);
        }

    }
}