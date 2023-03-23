using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityMvvmToolkit.Core;
using UnityMvvmToolkit.Core.Interfaces;

namespace ViewModels
{
    public class IntroViewModel : BaseViewModel
    {
        private int _currentPage;
        public int CurrentPage
        {
            get => _currentPage;
            set  
            {
                if (Set(ref _currentPage, value))
                {
                    OnPropertyChanged(nameof(IsLastPage));
                }
            }
        }

        public bool IsLastPage => CurrentPage == 2;

        public event EventHandler OnLoginScreen;
        public IntroViewModel()
        {
            NextPageCommand = new Command(NextPage);
            PreviousPageCommand = new Command(PreviousPage);
            NextScreenCommand = new Command(NextScreen);

        }

        public ICommand NextPageCommand { get; }
        public ICommand PreviousPageCommand { get; }
        public ICommand NextScreenCommand { get; }


        private void NextPage()
        {
            CurrentPage++;
        }
        public void PreviousPage() => CurrentPage--;

        public void NextScreen() 
        {
            OnLoginScreen?.Invoke(this, EventArgs.Empty);
        }
    }
}
