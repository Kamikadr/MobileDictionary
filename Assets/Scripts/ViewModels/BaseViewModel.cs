using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityMvvmToolkit.Core;
namespace ViewModels
{
    public class BaseViewModel : ViewModel
    {
        private bool _isActive;

        public bool IsActive => _isActive;

        public void Show() 
        {
            _isActive = true;
        }
        public void Hide() 
        {
            _isActive = false;
        }

    }
}