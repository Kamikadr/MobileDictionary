using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityMvvmToolkit.Core.Interfaces;

namespace BindableElements
{
    public class BindableScreenPage : VisualElement, IBindableUIElement
    {
        public string BindingActivityPath { get; set; }

        public new class UxmlFactory : UxmlFactory<BindableScreenPage, UxmlTraits>
        {
        }

        public new class UxmlTraits : VisualElement.UxmlTraits
        {
            private readonly UxmlStringAttributeDescription _activeBindingPath = new()
            { name = "binding-activity-path", defaultValue = "" };

            public override void Init(VisualElement visualElement, IUxmlAttributes bag, CreationContext context)
            {
                base.Init(visualElement, bag, context);

                var bindableScreenPage = (BindableScreenPage)visualElement;
                bindableScreenPage.BindingActivityPath = _activeBindingPath.GetValueFromBag(bag, context);

            }
        }
    }
}