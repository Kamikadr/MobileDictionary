using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityMvvmToolkit.Core.Interfaces;
using UnityMvvmToolkit.UITK.BindableUIElements;

namespace BindableUIElementWrappers
{
    public class BindablePasswordTextFieldWrapper : BindableNameTextFieldWrapper
    {
        private const string OpenPasswordClassName = "unity-text-field__password-eye__icon--opened";
        private const string ClosePasswordClassName = "unity-text-field__password-eye__icon--closed";

        private readonly BindablePasswordTextField _passwordTextField;
        private BindableButton _eyeButton;
        private VisualElement _eyeIcon;
        private bool _isPasswordVisible = false;
        public BindablePasswordTextFieldWrapper(BindablePasswordTextField textField, IObjectProvider objectProvider)
            : base(textField, objectProvider) 
        {
            _passwordTextField = textField;
            _eyeButton = textField.Q<BindableButton>("VisibilityEyeButton");
            _eyeButton.clicked += OnClicked;
            _eyeIcon = textField.Q<VisualElement>("EyeIcon");
            _eyeIcon.AddToClassList(ClosePasswordClassName);
        }
        private void OnClicked()
        {
            if (_isPasswordVisible) 
            {
                _passwordTextField.isPasswordField = false;

                _eyeIcon.AddToClassList(ClosePasswordClassName);
                _eyeIcon.RemoveFromClassList(OpenPasswordClassName);
            }
            else
            {
                _passwordTextField.isPasswordField = true;

                _eyeIcon.AddToClassList(OpenPasswordClassName);
                _eyeIcon.RemoveFromClassList(ClosePasswordClassName);
            }

            _isPasswordVisible = !_isPasswordVisible;
        }
    }
}