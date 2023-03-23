using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ViewModels;
using Zenject;

public class App : MonoBehaviour
{
    private BaseViewModel _activeScreen;

    [Inject] IntroViewModel _introViewModel;
    [Inject] LogInViewModel _logInViewModel;


    private void Awake()
    {
        
    }
    private void Start()
    {
        ShowView(_logInViewModel);
    }
    private void OnEnable()
    {
        _introViewModel.OnLoginScreen += OnLoginScreen;

        _logInViewModel.OnSignUp += OnSignUp;
        _logInViewModel.OnLoginBackClick += OnLoginBack;
    }

    private void OnLoginScreen(object sender, EventArgs e)
    {
        ShowView(_logInViewModel);
    }

    private void OnLoginBack(object sender, EventArgs e)
    {
        ShowView(_introViewModel);
    }

    private void OnSignUp(object sender, EventArgs e)
    {
        
    }

    private void OnDisable()
    {
        
    }



    private void ShowView(BaseViewModel viewModel)
    {
        if(_activeScreen != null)
        {
            _activeScreen.Hide();
        }
        viewModel.Show();
        _activeScreen = viewModel;
    }
}
