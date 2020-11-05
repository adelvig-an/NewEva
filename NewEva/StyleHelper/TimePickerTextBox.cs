using System.Windows;
using System.Windows.Controls;

namespace NewEva.StyleHelper
{
    public class TimePickerTextBox : TextBox
    {
        static TimePickerTextBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TimePickerTextBox), new FrameworkPropertyMetadata(typeof(TimePickerTextBox)));
        }
    }
}