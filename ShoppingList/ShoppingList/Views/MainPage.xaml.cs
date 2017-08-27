using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ShoppingList.Views
{
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
    }
}
