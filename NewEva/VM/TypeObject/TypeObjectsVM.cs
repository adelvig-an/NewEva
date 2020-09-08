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
        public TypeObjectsVM()
        {
            AddCommand = new RelayCommand(_ => Add());
            Items = new ObservableCollection<ItemVM>();
            Categories = ListBuilding.Categories;
            RemoveCommand = new RelayCommand(item => Remove(item as ItemVM));
        }

        public void Add()
        {
            Items.Add(new ItemVM("Описание объекта " + (Items.Count+1)));
        }

        public void Remove(ItemVM item)
        {
            Items.Remove(item); //удаление элемента
            for (int i = 0; i < Items.Count; i++) //получение i-го элемента из коллекций
            {
                    Items[i].ButtonContent = "Описание объекта " + (i + 1);
            }
        }

        public IEnumerable<Category> Categories { get; set; }
        public ICommand AddCommand { get; }
        public ICommand RemoveCommand { get; }
        public ObservableCollection<ItemVM> Items { get; }

        //Для сохранения выбраных значений в списке
        private string selectedCategory;
        public string SelectedCategory
        { 
            get => selectedCategory;
            set => SetProperty(ref selectedCategory, value);
        }

        private string selectedBuilding;
        public string SelectedBuilding
        {
            get => selectedBuilding;
            set => SetProperty(ref selectedBuilding, value);
        }

    }
}
