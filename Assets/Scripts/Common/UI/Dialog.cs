using System;
using Common.Interfaces;
using UnityEngine;
using UnityEngine.UIElements;

namespace Common.UI
{
    public class Dialog : VisualElement, IDialog
    {
        private bool _isVisible;

        private Label _textLabel;
        private Button _okButton;
        private Button _blockerButton;

        public Dialog()
        {
            if (Application.isPlaying)
            {
                RegisterCallback<GeometryChangedEvent>(OnLayoutCalculated);
            }
        }


        public bool IsShowing { get; set; }

        public event EventHandler Closed;

        public void Show(string text)
        {
            if (_isVisible)
            {
                return;
            }

            _isVisible = true;
            style.display = DisplayStyle.Flex;

            if (_okButton != null)
            {
                _okButton.clicked += OnOkButtonClicked;
            }

            if (_blockerButton != null)
            {
                _blockerButton.visible = true;
                _blockerButton.clicked += OnOkButtonClicked;
            }

            _textLabel.text = text;
            IsShowing = true;
        }

        public void Hide()
        {
            if (_isVisible == false)
            {
                return;
            }

            _isVisible = false;
            style.display = DisplayStyle.None;

            if (_okButton != null)
            {
                _okButton.clicked -= OnOkButtonClicked;
            }

            if (_blockerButton != null)
            {
                _blockerButton.visible = false;
                _blockerButton.clicked -= OnOkButtonClicked;
            }

            IsShowing = false;
            Closed?.Invoke(this, EventArgs.Empty);
        }

        private void OnOkButtonClicked()
        {
            Hide();
        }

        private void OnLayoutCalculated(GeometryChangedEvent e)
        {
            try
            {
                _textLabel = this.Q<Label>("Text");

                _blockerButton = parent?.Q<Button>("Blocker");
            }
            finally
            {
                style.display = DisplayStyle.None;
                UnregisterCallback<GeometryChangedEvent>(OnLayoutCalculated);
            }
        }

        public new class UxmlFactory : UxmlFactory<Dialog, UxmlTraits>
        {
        }

        public new class UxmlTraits : VisualElement.UxmlTraits
        {
        }
    }
}