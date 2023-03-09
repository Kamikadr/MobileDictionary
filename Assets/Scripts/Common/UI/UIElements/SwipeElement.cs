using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SwipeElement : SwipeCatcher
{


    private bool _isDragMode;
    private float _decreasePositionX;
    private float _increasePositionX;

    private float startX;
    private float endX;

    private readonly VisualElement _swipeElement;

    public SwipeElement(VisualElement swipeElement)
    {
        _swipeElement = swipeElement;
    }

    public event EventHandler Next;
    public event EventHandler Back;

    public void Initialize()
    {
        _decreasePositionX = _swipeElement.resolvedStyle.left - _swipeElement.resolvedStyle.width / 4;
        _increasePositionX = _swipeElement.resolvedStyle.left + _swipeElement.resolvedStyle.width / 4;
    }

    protected override void ProcessDownEvent(EventBase eventBase, Vector2 localPosition, int pointerId)
    {
        base.ProcessDownEvent(eventBase, localPosition, pointerId);

        if (eventBase.target == _swipeElement)
        {
            _isDragMode = true;
            startX = localPosition.x;
        }
    }

    protected override void ProcessUpEvent(EventBase eventBase, Vector2 localPosition, int pointerId)
    {
        base.ProcessUpEvent(eventBase, localPosition, pointerId);

        if (_isDragMode)
        {
            _isDragMode = false;
            endX = localPosition.x;
            EndThumbMove(localPosition).Forget();
        }
    }

    private async UniTaskVoid EndThumbMove(Vector2 localPosition)
    {
        await UniTask.Yield();
        if (endX - startX <= _decreasePositionX)
        {
            Next?.Invoke(this, EventArgs.Empty);
        }
        else if (endX - startX >= _increasePositionX)
        {
            Back?.Invoke(this, EventArgs.Empty);
        }
    }
}
