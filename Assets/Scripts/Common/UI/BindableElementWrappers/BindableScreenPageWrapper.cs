using BindableElements;
using UnityMvvmToolkit.Core;
using UnityMvvmToolkit.Core.Interfaces;

namespace BindableUIElementWrappers
{
    public class BindableScreenPageWrapper : BindablePropertyElement
    {
        private readonly BindableScreenPage _bindableScreenPageWrapper;
        private readonly IReadOnlyProperty<bool> _visibilityProperty;

        public BindableScreenPageWrapper(BindableScreenPage bindableScreenPageWrapper, IObjectProvider objectProvider)
            : base(objectProvider)
        {
            _bindableScreenPageWrapper = bindableScreenPageWrapper;
            _visibilityProperty = GetReadOnlyProperty<bool>(bindableScreenPageWrapper.BindingActivityPath);
        }

        public override void UpdateValues()
        {
            _bindableScreenPageWrapper.visible = _visibilityProperty.Value;
        }
    }
}