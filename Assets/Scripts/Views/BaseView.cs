using System;
using System.ComponentModel;
using UnityEngine.UIElements;
using UnityMvvmToolkit.Core.Interfaces;
using UnityMvvmToolkit.UITK;
using ViewModels;
using Zenject;

namespace Views
{
    public abstract class BaseView<TBindingContext> : DocumentView<TBindingContext>
        where TBindingContext :  BaseViewModel
    {
        [Inject] private IBindableElementsFactory _bindableElementsFactory;
        [Inject] private TBindingContext _viewModel;

        private void Show(object sender, EventArgs args) 
        {
            RootVisualElement.style.display = DisplayStyle.Flex;
        }
        private void Hide(object sender, EventArgs args)
        {
            RootVisualElement.style.display = DisplayStyle.None;
        }
        protected override IBindableElementsFactory GetBindableElementsFactory()
        {
            return _bindableElementsFactory;
        }
        protected override TBindingContext GetBindingContext()
        {
            return _viewModel;
        }
    }
}