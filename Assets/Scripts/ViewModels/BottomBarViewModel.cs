using System;
using UnityMvvmToolkit.Core;
using UnityMvvmToolkit.Core.Interfaces;

namespace ViewModels
{
    public class BottomBarViewModel : BaseViewModel
    {
        public event EventHandler OnDictionaryView;
        public event EventHandler OnTrainingView;
        public event EventHandler OnVideoView;
        public BottomBarViewModel()
        {
            DictionaryCommand = new Command(ShowDictionaryView);
            TrainingCommand = new Command(ShowTrainingView);
            VideoCommand = new Command(ShowVideoView);
        }

        public ICommand DictionaryCommand { get; }
        public ICommand TrainingCommand { get; }
        public ICommand VideoCommand { get; }


        private void ShowDictionaryView()
        {
            OnDictionaryView?.Invoke(this, EventArgs.Empty);
        }
        private void ShowTrainingView()
        {
            OnTrainingView?.Invoke(this, EventArgs.Empty);
        }
        private void ShowVideoView()
        {
            OnVideoView?.Invoke(this, EventArgs.Empty);
        }
    }
}