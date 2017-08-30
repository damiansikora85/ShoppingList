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

namespace ShoppingList.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
	{
        private ViewModels.MainPageViewModel viewModel;

		public MainPage()
		{
			InitializeComponent();
            BindingContext = viewModel = new ViewModels.MainPageViewModel();
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

        protected override void OnAppearing()
        {
            viewModel.Update();
        }
    }
}
