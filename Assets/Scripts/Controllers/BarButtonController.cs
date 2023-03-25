using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityMvvmToolkit.UITK.BindableUIElements;

public class BarButtonController : IDisposable
{
    private const string ActiveIconClassName = "bottom-bar__button__icon--active";
    private const string UnactiveIconClassName = "bottom-bar__button__icon--unactive";
    private const string UnactiveLabelClassName = "bottom-bar__button__label--unactive";
    private const string ActiveLabelClassName = "bottom-bar__button__label--active";
    private readonly VisualElement _icon;
    private readonly Label _label;
    private readonly BindableButton _button;
    private readonly Action<BarButtonController> _actionOnActiveButtonChange;
    public BarButtonController(VisualElement visualElement, Action<BarButtonController> actionOnActiveButtonChange = null)
    {
        _icon = visualElement.Q<VisualElement>("Icon");
        _label = visualElement.Q<Label>("Label");
        _button = (BindableButton) visualElement;
        _button.clicked += OnClick;

        _actionOnActiveButtonChange = actionOnActiveButtonChange;
    }

    private void OnClick()
    {
        _actionOnActiveButtonChange?.Invoke(this);
    }

    public void Deactivate()
    {
        _icon.RemoveFromClassList(ActiveIconClassName);
        _icon.AddToClassList(UnactiveIconClassName);

        _label.RemoveFromClassList(ActiveLabelClassName);
        _label.AddToClassList(UnactiveLabelClassName);
    }
    public void Activate() 
    {
        _icon.RemoveFromClassList(UnactiveIconClassName);
        _icon.AddToClassList(ActiveIconClassName);

        _label.RemoveFromClassList(UnactiveLabelClassName);
        _label.AddToClassList(ActiveLabelClassName);
    }
    public void Dispose()
    {
        _button.clicked -= OnClick;
    }
}
