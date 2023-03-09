using BindableElements;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityMvvmToolkit.Core;
using UnityMvvmToolkit.Core.Interfaces;

namespace BindableUIElementWrappers
{
    public class BindablePagenationWrapper : BindablePropertyElement
    {
        private readonly BindablePagination _bindablePagination;
        private readonly IReadOnlyProperty<int> _pageProperty;
        public BindablePagenationWrapper(BindablePagination bindablePagination ,IObjectProvider objectProvider) : base(objectProvider)
        {
            _bindablePagination = bindablePagination;

            _pageProperty = GetReadOnlyProperty<int>(bindablePagination.BindingActivePagePath);



        }

        public override void UpdateValues()
        {
            _bindablePagination.ChangeActivePage(_pageProperty.Value);
        }
    }
}