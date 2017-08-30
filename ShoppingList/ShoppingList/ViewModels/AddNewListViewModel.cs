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

        private string originalListName;

        public AddNewListViewModel()
        {
            ItemsList = new ObservableCollection<string>();
            IsEditMode = true;
            originalListName = "";
            Setup();
        }

        public AddNewListViewModel(ShoppingListModel shoppingList)
        {
            ItemsList = shoppingList.Items;
            ListName = originalListName = shoppingList.Name;
            IsEditMode = false;
            Setup();
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
                if (originalListName == "")
                {
                    ShoppingListModel newShoppingList = new ShoppingListModel(ListName)
                    {
                        Items = ItemsList
                    };

                    Services.ShoppingListManager.Instance.SavedLists.Add(newShoppingList);
                }
                else
                {
                    ShoppingListModel shoppingList = Services.ShoppingListManager.Instance.SavedLists.Where(elem => elem.Name == originalListName).FirstOrDefault();
                    shoppingList.Update(ListName);
                }
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
