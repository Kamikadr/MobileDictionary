using UnityEngine.UIElements;
using UnityMvvmToolkit.Core.Interfaces;

public class BindableIntroInfoContainer : VisualElement, IBindableUIElement
{
    public string BindingActivePagePath { get; set; }

    public new class UxmlFactory : UxmlFactory<BindableIntroInfoContainer, UxmlTraits>
    {
    }

    public new class UxmlTraits : VisualElement.UxmlTraits
    {
        private readonly UxmlStringAttributeDescription _nextCommandAttribute = new()
        { name = "binding-active-page-path", defaultValue = "" };


        public override void Init(VisualElement visualElement, IUxmlAttributes bag, CreationContext context)
        {
            base.Init(visualElement, bag, context);

            var bindablePagination = (BindableIntroInfoContainer)visualElement;
            bindablePagination.BindingActivePagePath = _nextCommandAttribute.GetValueFromBag(bag, context);

        }
    }
}
