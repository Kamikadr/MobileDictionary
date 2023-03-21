using System;

namespace Common.UI
{
    public interface IDialog
    {
        bool IsShowing { get; set; }
        event EventHandler Closed;

        void Show(string text);
        void Hide();
    }
}