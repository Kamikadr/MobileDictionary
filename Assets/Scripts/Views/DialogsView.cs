using Common.UI;
using UnityEngine.UIElements;
using UnityMvvmToolkit.UITK;

namespace Views
{
    public class DialogsView : DocumentView<DialogsViewModel>
    {
        protected override void OnInit()
        {
            base.OnInit();

            ErrorDialog = RootVisualElement.Q<Dialog>("ErrorDialog");
        }

        public IDialog ErrorDialog { get; private set; }
    }
}