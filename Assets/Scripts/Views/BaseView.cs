using System.ComponentModel;
using UnityMvvmToolkit.Core.Interfaces;
using UnityMvvmToolkit.UITK;
using Zenject;

namespace Views
{
    public abstract class BaseView<TBindingContext> : DocumentView<TBindingContext>, IBaseView
        where TBindingContext : class, INotifyPropertyChanged
    {
        [Inject] private IBindableElementsFactory _bindableElementsFactory;
        [Inject] private TBindingContext _viewModel;


        public void Show() 
        {
            gameObject.SetActive(true);
        }
        public void Hide()
        {
            gameObject.SetActive(false);
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