using Common.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Views;

namespace Common.Services
{
    public class DialogService : MonoBehaviour, IDialogService
    {
        [SerializeField] private DialogsView _dialogsView;

        public void ShowErrorDialog()
        {
            _dialogsView.ErrorDialog.ShowErrorDialogAsync("ERROR");
        }

        public void ShowErrorDialog(string text)
        {
            _dialogsView.ErrorDialog.ShowErrorDialogAsync(text).Forget();
        }
    }
}