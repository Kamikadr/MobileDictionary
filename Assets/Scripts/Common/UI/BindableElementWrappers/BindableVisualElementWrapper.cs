using UnityMvvmToolkit.Core;
using UnityMvvmToolkit.Core.Interfaces;

namespace BindableUIElementWrappers
{
    public class BindableVisualElementWrapper : BindablePropertyElement
    {
        private readonly BindableVisualElement _bindableVisualElement;
        private readonly IReadOnlyProperty<bool> _visibilityProperty;

        public BindableVisualElementWrapper(BindableVisualElement bindableVisualElement, IObjectProvider objectProvider)
            : base(objectProvider)
        {
            _bindableVisualElement = bindableVisualElement;
            _visibilityProperty = GetReadOnlyProperty<bool>(bindableVisualElement.BindingVisibilityPath);
        }

        public override void UpdateValues()
        {
            _bindableVisualElement.visible = _visibilityProperty.Value;
        }
    }
}