using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityMvvmToolkit.UITK.BindableUIElements;

public class BindablePasswordTextField : BindableNameTextField
{
    private const string PasswordEyeClassName = "unity-text-field__password-eye";
    private const string IconEyeClassName = "unity-text-field__password-eye__icon";



    public BindablePasswordTextField() : base() 
    {
        CreatePasswordEye();
    }

    private void CreatePasswordEye()
    {
        var eye = new BindableButton();
        eye.name = "VisibilityEyeButton";
        eye.AddToClassList(PasswordEyeClassName);
        contentContainer.Add(eye);

        var eyeIcon = new VisualElement();
        eyeIcon.name = "EyeIcon";
        eyeIcon.AddToClassList(IconEyeClassName);
        eye.Add(eyeIcon);    
    }

    public new class UxmlFactory : UxmlFactory<BindablePasswordTextField, UxmlTraits>
    {
    }

    public new class UxmlTraits : BindableNameTextField.UxmlTraits
    {
    }
}
