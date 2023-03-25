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
    [Inject] DictionaryViewModel _dictionaryViewModel;
    [Inject] TrainingViewModel _trainingViewModel;
    [Inject] VideoViewModel _videoViewModel;

    [Inject] BottomBarViewModel _bottomBarViewModel;


    private void Awake()
    {
        
    }
    private void Start()
    {
        ShowView(_introViewModel);
        HideSubView(_bottomBarViewModel);
    }
    private void OnEnable()
    {
        _introViewModel.OnLoginScreen += OnLoginScreen;

        _logInViewModel.OnSignUp += OnSignUp;
        _logInViewModel.OnLoginBackClick += OnLoginBack;

        _bottomBarViewModel.OnDictionaryView += OnDictionaryView;
        _bottomBarViewModel.OnTrainingView += OnTrainingView;
        _bottomBarViewModel.OnVideoView += OnVideoView;
    }

    private void OnVideoView(object sender, EventArgs e)
    {
        if (_videoViewModel.IsActive)
        {
            return;
        }
        ShowView(_videoViewModel);
    }

    private void OnTrainingView(object sender, EventArgs e)
    {
        if(_trainingViewModel.IsActive)
        {
            return;
        }
        ShowView(_trainingViewModel);
    }

    private void OnDictionaryView(object sender, EventArgs e)
    {
        if(_dictionaryViewModel.IsActive)
        {
            return;
        }
        ShowView(_dictionaryViewModel);
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
        ShowView(_dictionaryViewModel);
        ShowSubView(_bottomBarViewModel);
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
    private void ShowSubView(BaseViewModel viewModel) 
    {
        viewModel.Show();
    }
    private void HideSubView(BaseViewModel viewModel) 
    {
        viewModel.Hide();
    }

}
