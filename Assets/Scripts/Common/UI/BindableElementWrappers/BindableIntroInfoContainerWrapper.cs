using UnityEngine.UIElements;
using UnityMvvmToolkit.Core;
using UnityMvvmToolkit.Core.Interfaces;

public class BindableIntroInfoContainerWrapper: BindablePropertyElement
{
    private readonly BindableIntroInfoContainer _bindablePagination;
    private readonly IReadOnlyProperty<int> _pageProperty;
    private VisualElement _currentPage;
    public BindableIntroInfoContainerWrapper(BindableIntroInfoContainer bindablePagination, IObjectProvider objectProvider) : base(objectProvider)
    {
        _bindablePagination = bindablePagination;

        _pageProperty = GetReadOnlyProperty<int>(bindablePagination.BindingActivePagePath);
    }

    public override void UpdateValues()
    {
        ShowInfo(_pageProperty.Value);
    }
    private void ShowInfo(int value) 
    {
        if (value >= 0 && value <= _bindablePagination.childCount - 1)
        {
            if (_currentPage != null)
            {
                Hide(_currentPage);
            }
            Show(_bindablePagination.contentContainer[value]);
            _currentPage = _bindablePagination.contentContainer[value];
        }
    }

    private void Hide(VisualElement visualElement)
    {
        visualElement.style.display = DisplayStyle.None;
    }
    private void Show(VisualElement visualElement)
    {
        visualElement.style.display = DisplayStyle.Flex;
    }
}
