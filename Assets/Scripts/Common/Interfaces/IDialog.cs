using Cysharp.Threading.Tasks;
using System;

namespace Common.UI
{
    public interface IDialog
    {
        UniTaskVoid ShowErrorDialogAsync(string text);
    }
}