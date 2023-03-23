using BindableElements;
using BindableElementWrappers;
using BindableUIElementWrappers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityMvvmToolkit.Core.Interfaces;
using UnityMvvmToolkit.UITK;

public class CustomBindableFactory : BindableElementsFactory
{

    public CustomBindableFactory()
    {

    }
    public override IBindableElement Create(IBindableUIElement bindableUiElement, IObjectProvider objectProvider)
    {
        return bindableUiElement switch
        {
            BindablePagination bindablePagination => new BindablePagenationWrapper(bindablePagination, objectProvider),
            BindableSwipePage bindableSwipePage => new BindableSwipePageWrapper(bindableSwipePage, objectProvider),
            IntroInfoContainer introInfoContainer => new BindableIntroInfoContainerWrapper(introInfoContainer, objectProvider),
            BindableVisualElement bindableVisualElement => new BindableVisualElementWrapper(bindableVisualElement, objectProvider),

            _ => base.Create(bindableUiElement, objectProvider)
        };
    }
}
