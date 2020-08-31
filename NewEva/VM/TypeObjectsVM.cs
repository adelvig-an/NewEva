using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using NewEva.Model;

namespace NewEva.VM
{
    public class TypeObjectsVM : PageVM
    {
        public override string Name => PageNames.TypeObjectsPage;

        public TypeObjectsVM()
        {
            AddCommand = new RelayCommand(_ => Add());
            Items = new ObservableCollection<ItemVM>();
            Categories = ListBuilding.Categories;
            RemoveItem = new RelayCommand(item => RemoveCommand(item as ItemVM));
        }

        public int n = 1;
        public void Add()
        {
            Items.Add(new ItemVM("Описание объекта " + n));
            n++;
        }

        public void RemoveCommand(ItemVM item)
        {
            Items.Remove(item); //удаление Элемента
            for (int i = 0; i < Items.Count; i--) // получение i-го элемента из коллекций
            {
                if (true)
                {
                    item.ButtonContent = "Описание объекта " + n;
                }
            }
        }

        public IEnumerable<Category> Categories { get; set; }
        public ICommand AddCommand { get; }
        public ICommand RemoveItem { get; }
        public ObservableCollection<ItemVM> Items { get; }

    }
}
