using System;
using System.Collections.Generic;
using System.Text;
using ShoppingList.Models;
using System.Collections.ObjectModel;

namespace ShoppingList.ViewModels
{
    public class MainPageViewModel : Helpers.ObservableObject
    {
        public ObservableCollection<ShoppingListModel> ShoppingLists { get; set; }

        public MainPageViewModel()
        {
            ShoppingLists = ShoppingList.Services.ShoppingListManager.Instance.SavedLists;
        }

        public void Update()
        {
            OnPropertyChanged("ShoppingLists");
        }
    }
}
