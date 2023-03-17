using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ViewModels;
using Zenject;

public class App : MonoBehaviour
{
    private BaseViewModel _activeScreen;

    [Inject] IntroViewModel _introView;


    private void Awake()
    {
        
    }
    private void Start()
    {
        ShowView(_introView);
    }
    private void OnEnable()
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
