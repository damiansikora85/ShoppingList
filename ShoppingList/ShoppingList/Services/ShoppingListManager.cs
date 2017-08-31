using System;
using System.Collections.Generic;
using System.Text;
using ShoppingList.Models;
using System.Collections.ObjectModel;
using SQLite;
using Xamarin.Forms;
using ShoppingList.Helpers;

namespace ShoppingList.Services
{
    public class ShoppingListManager
    {
        private static ShoppingListManager instance;
        private ShoppingDatabase database;

        public ShoppingDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new ShoppingDatabase(DependencyService.Get<IFileHelper>().GetLocalFilePath("shoppingDatabase.db3"));
                }
                return database;
            }
        }

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
        }
    }
}
