using System.Collections;
using System.Collections.Generic;
using UIElements;
using UnityEngine;
using UnityEngine.UIElements;
using UnityMvvmToolkit.Core.Interfaces;

namespace BindableElements { 
public class BindablePagination : Pagination, IBindableUIElement
    {
    public string BindingActivePagePath { get; set; }

    public new class UxmlFactory : UxmlFactory<BindablePagination, UxmlTraits>
    {
    }

    public new class UxmlTraits : Pagination.UxmlTraits
    {
        private readonly UxmlStringAttributeDescription _nextCommandAttribute = new()
        { name = "binding-active-page-path", defaultValue = "" };


        public override void Init(VisualElement visualElement, IUxmlAttributes bag, CreationContext context)
        {
            base.Init(visualElement, bag, context);

            var bindablePagination = (BindablePagination)visualElement;
            bindablePagination.BindingActivePagePath = _nextCommandAttribute.GetValueFromBag(bag, context);

        }
    }
}}
