using UnityMvvmToolkit.Core.Interfaces;
using UnityMvvmToolkit.UITK.BindableUIElementWrappers;

public class BindableNameTextFieldWrapper : BindableTextFieldWrapper
{
    private readonly BindableNameTextField _textField;
    private readonly IProperty<string> _valueProperty;
    public BindableNameTextFieldWrapper(BindableNameTextField textField, IObjectProvider objectProvider) : base(textField, objectProvider) 
    {
        _textField = textField;
        _valueProperty = GetProperty<string>(textField.BindingValuePath);
    }
    public override void UpdateValues()
    {
        _textField.SetPlaceholderVisible(string.IsNullOrEmpty(_valueProperty.Value));
    }
}
