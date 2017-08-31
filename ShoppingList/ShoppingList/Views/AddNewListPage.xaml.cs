using ShoppingList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShoppingList.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddNewListPage : ContentPage
	{
        private ViewModels.AddNewListViewModel viewModel;

        public AddNewListPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new ViewModels.AddNewListViewModel();
        }

        public AddNewListPage (ShoppingListModel shoppingList)
		{
			InitializeComponent ();
            BindingContext = viewModel = new ViewModels.AddNewListViewModel(shoppingList);
		}

        async void OnSaveList(object sender, EventArgs e)
        {
            await Navigation.PopAsync(true);
        }

        void OnNewItem(object sender, EventArgs e)
        {
            viewModel.AddNewItemToList();
        }

        void OnEditList(object sender, EventArgs e)
        {
            viewModel.SetEditMode();
        }
    }
}