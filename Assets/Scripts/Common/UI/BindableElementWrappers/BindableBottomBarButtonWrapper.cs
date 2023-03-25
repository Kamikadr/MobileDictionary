using BindableElements;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityMvvmToolkit.Core.Interfaces;
using UnityMvvmToolkit.UITK.BindableUIElements;
using UnityMvvmToolkit.UITK.BindableUIElementWrappers;

public class BottomBarButtonsContainerWrapper : IDisposable, IBindableElement
{
    private BarButtonController _currentButtonController;
    private readonly List<IDisposable> _disposables;
    public BottomBarButtonsContainerWrapper(BottomBarButtonsContainer container)
    {
        _disposables = new List<IDisposable>();
        foreach(VisualElement element in container.Children())
        {
            if(element is BindableBottomBarButton)
            {
                var controller = new BarButtonController(element, ActionOnActiveButtonChange);
                _disposables.Add(controller);
                if(_currentButtonController == null)
                {
                    _currentButtonController = controller;
                    controller.Activate();
                }
            }
        }
    }

    private void ActionOnActiveButtonChange(BarButtonController controller) 
    {
        if(_currentButtonController != null)
        {
            _currentButtonController.Deactivate();
        }
        controller.Activate();
        _currentButtonController = controller;
    }
    public void Dispose()
    {
        foreach (IDisposable disposable in _disposables)
        {
            disposable.Dispose();
        }
    }
}
