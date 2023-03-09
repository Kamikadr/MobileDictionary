using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Views;

public class App : MonoBehaviour
{
    [SerializeField] IntroView _introView;


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

    private void ShowView(IBaseView view)
    {
        view.Show();
    }
}
