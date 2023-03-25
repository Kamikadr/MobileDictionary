using BindableElements;
using BindableUIElementWrappers;
using UnityEngine.UIElements;
using UnityMvvmToolkit.Core.Interfaces;
using UnityMvvmToolkit.UITK;
using UnityMvvmToolkit.UITK.BindableUIElements;
using UnityMvvmToolkit.UITK.BindableUIElementWrappers;

public class CustomBindableFactory : BindableElementsFactory
{
    private readonly VisualTreeAsset itemAsset;
    public CustomBindableFactory()
    {

    }
    public override IBindableElement Create(IBindableUIElement bindableUiElement, IObjectProvider objectProvider)
    {
        return bindableUiElement switch
        {
            BindableScreenPage bindableScreenPage => new BindableScreenPageWrapper(bindableScreenPage, objectProvider),
            BindablePagination bindablePagination => new BindablePagenationWrapper(bindablePagination, objectProvider),
            BindableSwipePage bindableSwipePage => new BindableSwipePageWrapper(bindableSwipePage, objectProvider),
            BindablePasswordTextField bindablePasswordTextField => new BindablePasswordTextFieldWrapper(bindablePasswordTextField, objectProvider),
            BindableNameTextField bindableNameTextField => new BindableNameTextFieldWrapper(bindableNameTextField, objectProvider),
            BindableIntroInfoContainer bindableIntroInfoContainer => new BindableIntroInfoContainerWrapper(bindableIntroInfoContainer, objectProvider),
            BindableVisualElement bindableVisualElement => new BindableVisualElementWrapper(bindableVisualElement, objectProvider),
            BottomBarButtonsContainer barButtonsContainer => new BottomBarButtonsContainerWrapper(barButtonsContainer),
            BindableBottomBarButton bindableBottomBarButton => new BindableButtonWrapper(bindableBottomBarButton, objectProvider),
            BindableScrollView bindableScrollView => new BindableMeaningScrollViewWrapper(bindableScrollView, itemAsset, objectProvider),
            _ => base.Create(bindableUiElement, objectProvider)
        };
    }
}
