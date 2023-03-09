using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityMvvmToolkit.Core.Interfaces;

public class BindableSwipePage : SwipePage, IBindableUIElement
{
    public string NextCommand { get; set; }
    public string BackCommand { get; set; }

    public new class UxmlFactory : UxmlFactory<BindableSwipePage, UxmlTraits>
    {
    }

    public new class UxmlTraits : SwipePage.UxmlTraits
    {
        private readonly UxmlStringAttributeDescription _nextCommandAttribute = new()
        { name = "next-command", defaultValue = "" };

        private readonly UxmlStringAttributeDescription _backCommandAttribute = new()
        { name = "back-command", defaultValue = "" };

        public override void Init(VisualElement visualElement, IUxmlAttributes bag, CreationContext context)
        {
            base.Init(visualElement, bag, context);

            var bindableCounterSlider = (BindableSwipePage)visualElement;
            bindableCounterSlider.NextCommand = _nextCommandAttribute.GetValueFromBag(bag, context);
            bindableCounterSlider.BackCommand = _backCommandAttribute.GetValueFromBag(bag, context);
        }
    }
}
