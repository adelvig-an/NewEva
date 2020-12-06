using System;
using System.Collections.Generic;
using System.Text;
using NewEva.Model;

namespace NewEva.VM
{
    public class ItemVM : ViewModelBase
    {
        public ItemVM(string v) => ButtonContent = v;

        public Category SelectedCategory { get; set; }

        public BuildingBase SelectedBuilding { get; set; }

        private string buttonContent;
        public string ButtonContent
        {
            get => buttonContent;
            set
            {
                SetProperty(ref buttonContent, value);
            }
        }
    }
}
