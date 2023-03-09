using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SwipePage : VisualElement
{
    private SwipeElement _swipeElement;
    public SwipePage()
    {
        RegisterManipulator();
        RegisterCallback<GeometryChangedEvent>(OnLayoutCalculated);
    }

    public event EventHandler Next
    {
        add => _swipeElement.Next += value;
        remove => _swipeElement.Next -= value;
    }

    public event EventHandler Back
    {
        add => _swipeElement.Back += value;
        remove => _swipeElement.Back -= value;
    }

    private void RegisterManipulator()
    {
        _swipeElement = new SwipeElement(this);
        this.AddManipulator(_swipeElement);
    }

    private void OnLayoutCalculated(GeometryChangedEvent e)
    {
        _swipeElement.Initialize();
    }

    public new class UxmlFactory : UxmlFactory<SwipePage, UxmlTraits>
    {
    }

    public new class UxmlTraits : VisualElement.UxmlTraits
    {
    }
}
