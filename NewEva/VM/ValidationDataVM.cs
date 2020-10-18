using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace NewEva.VM
{
    public class ValidationDataVM : PageVM
    {
        public ObservableCollection<string> Errors { get; }

        public void AddErrorIf<T>(T value, Func<T, bool> validate, string error)
        {
            if (validate(value))
            {
                Errors.Add(error);
            }
        }

        private bool isVisible;
        public bool IsVisible
        {
            get => isVisible;
            set => SetProperty(ref isVisible, value);
        }
    }
}
