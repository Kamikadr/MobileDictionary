using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityMvvmToolkit.UITK.BindableUIElements;

namespace BindableElements
{
    public class BindableBottomBarButton : BindableButton
    {

        public bool IsActive { get; set; }
        public new class UxmlFactory : UxmlFactory<BindableBottomBarButton, UxmlTraits>
        {
        }

        public new class UxmlTraits : BindableButton.UxmlTraits
        {
        }
    }
}