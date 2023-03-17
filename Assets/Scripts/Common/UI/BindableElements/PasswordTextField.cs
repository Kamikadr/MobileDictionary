using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityMvvmToolkit.UITK.BindableUIElements;

public class PasswordTextField : BindableNameTextField
{
    public PasswordTextField()
    {

    }


    public new class UxmlFactory : UxmlFactory<PasswordTextField, UxmlTraits>
    {
    }

    public new class UxmlTraits : BindableNameTextField.UxmlTraits
    {
    }
}
