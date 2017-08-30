using System;
using System.Collections.Generic;
using System.Text;
using ShoppingList.Models;
using System.Collections.ObjectModel;

namespace ShoppingList.Services
{
    public class ShoppingListManager
    {
        public ObservableCollection<ShoppingListModel> SavedLists { get; private set; }
        private static ShoppingListManager instance;

        public static ShoppingListManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new ShoppingListManager();

                return instance;
            }
        }

        private ShoppingListManager()
        {
            SavedLists = new ObservableCollection<ShoppingListModel>()
            {
                new ShoppingListModel("List1"),
                new ShoppingListModel("List2"),
                new ShoppingListModel("List3"),
                new ShoppingListModel("List4"),
                new ShoppingListModel("List5")
            };
        }

    }
}
