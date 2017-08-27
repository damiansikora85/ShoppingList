using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingList.ViewModels
{
    public class MainPageViewModel : Helpers.ObservableObject
    {
        public List<string> ShoppingLists { get; set; }

        public MainPageViewModel()
        {
            ShoppingLists = ShoppingList.Services.ShoppingListManager.Instance.SavedLists;
        }

        public void AddNewShoppingList()
        {

        }
    }
}
