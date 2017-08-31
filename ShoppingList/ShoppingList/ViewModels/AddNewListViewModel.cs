using System;
using System.Collections.Generic;
using System.Text;

using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;

using Xamarin.Forms;
using ShoppingList.Models;
using System.Collections.ObjectModel;
using System.Linq;

namespace ShoppingList.ViewModels
{
    public class AddNewListViewModel : Helpers.ObservableObject
    {
        public string ListName { get; set; }
        public ObservableCollection<string> ItemsList { get; set; }
        public string NewItemName { get; set; }
        public bool IsEditMode { get; set; }

        public ICommand SaveListCommand { get; set; }
        public ICommand RemoveItemCommand { get; set; }

        private ShoppingListModel currentShoppingListModel;

        private int currentListID;

        public AddNewListViewModel()
        {
            ItemsList = new ObservableCollection<string>();
            IsEditMode = true;
            currentListID = -1;
            Setup();
            currentShoppingListModel = new ShoppingListModel();
        }

        public AddNewListViewModel(ShoppingListModel shoppingList)
        {
            ListName = shoppingList.Name;
            ItemsList = shoppingList.Items;
            currentListID = shoppingList.ID;
            IsEditMode = false;
            Setup();
            currentShoppingListModel = shoppingList;
        }

        private void Setup()
        {
            SaveListCommand = new Command(SaveShoppingList);
            RemoveItemCommand = new Command((e) =>
            {
                string item = e as string;
                ItemsList.Remove(item);
            });
        }
        
        public void SetEditMode()
        {
            IsEditMode = true;
            OnPropertyChanged("IsEditMode");
        }

        public void SaveShoppingList()
        {
            if (ListName != null && ListName.Length > 0)
            {
                currentShoppingListModel.Name = ListName;
                currentShoppingListModel.Items = ItemsList;
                Services.ShoppingListManager.Instance.Database.SaveItemAsync(currentShoppingListModel);
            }
        }

        public void AddNewItemToList()
        {
            ItemsList.Add(NewItemName);
            NewItemName = "";
            OnPropertyChanged("NewItemName");
        }
    }
}
