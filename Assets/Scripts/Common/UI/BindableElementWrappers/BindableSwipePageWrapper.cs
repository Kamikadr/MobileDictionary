using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityMvvmToolkit.Core;
using UnityMvvmToolkit.Core.Interfaces;

public class BindableSwipePageWrapper : BindableCommandElement, IInitializable, IDisposable
{
    private readonly BindableSwipePage _swipePage;
    private readonly ICommand _nextCommand;
    private readonly ICommand _backCommand;

    public BindableSwipePageWrapper(BindableSwipePage counterSlider, IObjectProvider objectProvider)
        : base(objectProvider)
    {
        _swipePage = counterSlider;
        _nextCommand = GetCommand<ICommand>(counterSlider.NextCommand);
        _backCommand = GetCommand<ICommand>(counterSlider.BackCommand);
    }

    public bool CanInitialize => _nextCommand != null && _backCommand != null;

    public void Initialize()
    {
        _swipePage.Next += NextPage;
        _swipePage.Back += PreviousPage;
    }

    public void Dispose()
    {
        _swipePage.Next -= NextPage;
        _swipePage.Back -= PreviousPage;
    }

    private void NextPage(object sender, EventArgs e)
    {
        _nextCommand.Execute();
    }

    private void PreviousPage(object sender, EventArgs e)
    {
        _backCommand.Execute();
    }
}
