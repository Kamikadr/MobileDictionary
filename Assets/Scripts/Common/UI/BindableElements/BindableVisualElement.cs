using UnityEngine.UIElements;
using UnityMvvmToolkit.Core.Interfaces;

public class BindableVisualElement : VisualElement, IBindableUIElement
{
    public string BindingVisibilityPath { get; set; }

    public new class UxmlFactory : UxmlFactory<BindableVisualElement, UxmlTraits>
    {
    }

    public new class UxmlTraits : VisualElement.UxmlTraits
    {
        private readonly UxmlStringAttributeDescription _bindingVisibilityPathAttribute = new()
        { name = "binding-visibility-path", defaultValue = "" };

        public override void Init(VisualElement visualElement, IUxmlAttributes bag, CreationContext context)
        {
            base.Init(visualElement, bag, context);

            var bindableContentPage = (BindableVisualElement)visualElement;
            bindableContentPage.BindingVisibilityPath =
                _bindingVisibilityPathAttribute.GetValueFromBag(bag, context);
        }
    }
}