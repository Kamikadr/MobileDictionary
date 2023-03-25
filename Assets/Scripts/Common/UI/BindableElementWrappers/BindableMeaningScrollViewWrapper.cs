using UnityEngine.UIElements;
using UnityMvvmToolkit.Core.Interfaces;
using UnityMvvmToolkit.UITK.BindableUIElements;
using UnityMvvmToolkit.UITK.BindableUIElementWrappers;

public class BindableMeaningScrollViewWrapper : BindableScrollViewWrapper<MeaningItemController, MeaningItemData>
{
    public BindableMeaningScrollViewWrapper(BindableScrollView scrollView, VisualTreeAsset itemAsset, IObjectProvider objectProvider)
        : base(scrollView, itemAsset, objectProvider)
    {
    }

    protected override void OnBindItem(MeaningItemController item, MeaningItemData data)
    {
    }

    protected override MeaningItemController OnMakeItem(VisualElement itemAsset)
    {
        return new MeaningItemController();
    }
}
