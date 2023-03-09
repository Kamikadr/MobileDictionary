using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityMvvmToolkit.Core;
using UnityMvvmToolkit.Core.Interfaces;

namespace ViewModels
{
    public class IntroViewModel : ViewModel
    {
        private int _currentPage;

        public int CurrentPage 
        { 
            get => _currentPage;
            set => Set(ref _currentPage, value);
        }
         public IntroViewModel() 
        {
            NextPageCommand = new Command(NextPage);
            PreviousPageCommand = new Command(PreviousPage);
        }

        public ICommand NextPageCommand { get; }
        public ICommand PreviousPageCommand { get; }


        private void NextPage() => CurrentPage++;
        public void PreviousPage() => CurrentPage--;
    }
}
