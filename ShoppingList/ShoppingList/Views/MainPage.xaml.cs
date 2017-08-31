using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ShoppingList.Models;
using System.Collections.ObjectModel;
using System.Diagnostics;
using SQLite;

namespace ShoppingList.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

        async void AddNewList_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddNewListPage());
        }

        async void OnListSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as ShoppingListModel;
            if (item == null)
                return;

            await Navigation.PushAsync(new AddNewListPage(item));

            ShoppingListView.SelectedItem = null;
        }

        async void OnRemove(object sender, EventArgs args)
        {
            await UpdateListView();
        }

        protected override async void OnAppearing()
        {
            await UpdateListView();
        }

        private async Task UpdateListView()
        {
            List<ShoppingListModel> shoppingLists = await Services.ShoppingListManager.Instance.Database.GetItemsAsync();
            ShoppingListView.ItemsSource = shoppingLists;
            EmptyListWarning.IsVisible = shoppingLists.Count == 0;
        }
    }
}
