using BindableElements;
using BindableUIElementWrappers;
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
            BindableScreenPage bindableScreenPage => new BindableScreenPageWrapper(bindableScreenPage, objectProvider),
            BindablePagination bindablePagination => new BindablePagenationWrapper(bindablePagination, objectProvider),
            BindableSwipePage bindableSwipePage => new BindableSwipePageWrapper(bindableSwipePage, objectProvider),
            BindablePasswordTextField bindablePasswordTextField => new BindablePasswordTextFieldWrapper(bindablePasswordTextField, objectProvider),
            BindableNameTextField bindableNameTextField => new BindableNameTextFieldWrapper(bindableNameTextField, objectProvider),
            BindableIntroInfoContainer bindableIntroInfoContainer => new BindableIntroInfoContainerWrapper(bindableIntroInfoContainer, objectProvider),
            BindableVisualElement bindableVisualElement => new BindableVisualElementWrapper(bindableVisualElement, objectProvider),


            _ => base.Create(bindableUiElement, objectProvider)
        };
    }
}
