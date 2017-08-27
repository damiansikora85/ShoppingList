using System;
using System.Collections.Generic;
using System.Text;

using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;

using Xamarin.Forms;

namespace ShoppingList.ViewModels
{
    public class AddNewListViewModel : Helpers.ObservableObject
    {
        public string ListName { get; set; }
        public ICommand AddNewListCommand { get; set; }

        public AddNewListViewModel()
        {
            AddNewListCommand = new Command(AddNewShoppingList);
        }

        private void AddNewShoppingList()
        {
            Services.ShoppingListManager.Instance.SavedLists.Add(ListName);
        }
    }
}
