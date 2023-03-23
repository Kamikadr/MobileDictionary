using System;
using Common.Interfaces;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UIElements;

namespace Common.UI
{
    public class Dialog : VisualElement, IDialog
    {
        private bool _isActive;

        private Label _textLabel;

        public Dialog()
        {
            if (Application.isPlaying)
            {
                RegisterCallback<GeometryChangedEvent>(OnLayoutCalculated);
            }
        }




        private void OnLayoutCalculated(GeometryChangedEvent e)
        {
            try
            {
                _textLabel = this.Q<Label>("Text");

            }
            finally
            {
                SetOpacity(0);
                SetVisible(false);
                UnregisterCallback<GeometryChangedEvent>(OnLayoutCalculated);
            }
        }

        private async UniTask SetOpacityAsync(float value, float time = 1f)
        {
            var elapsedTime = 0f;
            while (elapsedTime < time)
            {
                style.opacity = Mathf.Lerp(style.opacity.value, value, elapsedTime/time);
                elapsedTime += Time.deltaTime;
                await UniTask.Yield();
            }
        }
        private void SetOpacity(float value) 
        {
            style.opacity = value;
        }
        private void SetVisible(bool value)
        {
            if (value)
            {
                style.display = DisplayStyle.Flex;
            }
            else
            {
                style.display = DisplayStyle.None;
            }
        }

        public async UniTaskVoid ShowErrorDialogAsync(string text) 
        {
            if (_isActive)
            {
                return;
            }
            _textLabel.text = text;

            _isActive = true;
            SetVisible(true);
            await SetOpacityAsync(1, 1f);
            await UniTask.Delay(1500);
            await SetOpacityAsync(0, 1f);
            SetVisible(false);
            _isActive = false;
        }
        public new class UxmlFactory : UxmlFactory<Dialog, UxmlTraits>
        {
        }

        public new class UxmlTraits : VisualElement.UxmlTraits
        {
        }
    }
}