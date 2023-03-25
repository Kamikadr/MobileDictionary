using UnityEngine.UIElements;
using UnityMvvmToolkit.Core.Interfaces;

public class BottomBarButtonsContainer : VisualElement, IBindableUIElement
{
    public new class UxmlFactory : UxmlFactory<BottomBarButtonsContainer, UxmlTraits>
    {
    }
    public new class UxmlTraits : VisualElement.UxmlTraits
    {
    }
}
