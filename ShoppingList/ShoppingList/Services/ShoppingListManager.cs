using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingList.Services
{
    public class ShoppingListManager
    {
        public List<string> SavedLists { get; private set; }
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
            SavedLists = new List<string>()
            {
                "List1",
                "List2",
                "List3",
                "List4",
                "List5"
            };
        }

    }
}
