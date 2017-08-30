using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

using Xamarin.Forms;
using ShoppingList.Services;
using System.Collections.ObjectModel;

namespace ShoppingList.Models
{
    public class ShoppingListModel : Helpers.ObservableObject
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }

        private ObservableCollection<string> items;
        public ObservableCollection<string> Items { get { return items; } set { items = value; itemsNum = value.Count; } }

        private int itemsNum;
        public int ItemsNum
        {
            get {return itemsNum; }
            set { SetProperty(ref itemsNum, value); }
        }
        public int ItemsBought { get { return 0; } }
        public ICommand RemoveListCommand { get; set; }

        public ShoppingListModel(string name)
        {
            Name = name;
            Items = new ObservableCollection<string>();

            RemoveListCommand = new Command(() => 
            ShoppingListManager.Instance.SavedLists.Remove(this)
            );
        }

        public void Update(string newName)
        {
            Name = newName;
            ItemsNum = items.Count;
        }
    }
}
