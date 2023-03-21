using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityMvvmToolkit.Core;
using UnityMvvmToolkit.Core.Interfaces;
using Zenject;

namespace ViewModels
{
    public class LogInViewModel : BaseViewModel
    {
        public event EventHandler OnSignUp;
        public event EventHandler OnLoginBackClick;
        private string _name = "";
        private string _email;
        private string _password;


        [Inject]
        public LogInViewModel() 
        {
            SignUpCommand = new Command(SignUp);
            SignInCommand = new Command(LogIn);
            BackCommand = new Command(Back);
        }

        public string Name 
        {
            get => _name;
            set => Set(ref _name, value);
        }
        public string Email 
        {
            get => _email;
            set => Set(ref _email, value);
        }
        public string Password 
        { 
            get => _password;
            set => Set(ref _password, value); 
        }


        public ICommand SignUpCommand { get; }
        public ICommand SignInCommand { get; }
        public ICommand BackCommand { get; }

        private void SignUp() 
        {
            if( string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password)) 
            {
                //Dialog Secvice
                return;
            }

            OnSignUp?.Invoke(this, EventArgs.Empty);
        }
        private void LogIn() 
        {
            OnSignUp?.Invoke(this, EventArgs.Empty);
        }

        private void Back() 
        {
            OnLoginBackClick?.Invoke(this, EventArgs.Empty);
        }
    }
}