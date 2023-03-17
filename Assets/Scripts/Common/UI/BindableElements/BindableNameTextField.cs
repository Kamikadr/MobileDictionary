using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityMvvmToolkit.UITK.BindableUIElements;

public class BindableNameTextField : BindableTextField
{
    private const string PlaceholderClassName = "placeholder";
    protected Label Placeholder;
    public string PlaceholderText 
    { 
        get => Placeholder.text;
        set => Placeholder.text = value; 
    }
    public BindableNameTextField() : base() 
    {
        CreatePlaceholder();
    }
    private void CreatePlaceholder() 
    {
        Placeholder = new Label();
        Placeholder.name = "Placeholder";
        Placeholder.pickingMode = PickingMode.Ignore;
        Placeholder.AddToClassList(PlaceholderClassName);
        contentContainer.Add(Placeholder);
    }
    public new class UxmlFactory : UxmlFactory<BindableNameTextField, UxmlTraits>
    {
    }

    public new class UxmlTraits : BindableTextField.UxmlTraits
    {
        private readonly UxmlStringAttributeDescription _placeholderText = new()
        { name = "placeholder-text", defaultValue = "placeholder" };

        public override void Init(VisualElement visualElement, IUxmlAttributes bag, CreationContext context)
        {
            base.Init(visualElement, bag, context);

            var bindablePagination = (BindableNameTextField)visualElement;
            bindablePagination.PlaceholderText = _placeholderText.GetValueFromBag(bag, context);

        }
    }
}
