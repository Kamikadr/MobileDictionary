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

        public bool IsActive 
        {
            get => _isActive;
            private set => Set(ref _isActive, value);
        }

        public void Show() 
        {
            IsActive = true;
        }
        public void Hide() 
        {
            IsActive = false;
        }

    }
}